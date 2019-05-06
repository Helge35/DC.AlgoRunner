using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using AlgoRunner.Api.Hubs;
using Hangfire;
using Hangfire.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace AlgoRunner.Api.Services
{
    public class AlgoExecutionService
    {
        string ExecutionPath { get; set; }
        string PytonExePath { get; set; }
        string ClientUrl { get; set; }
        IHubContext<MessageHub, IMessageHub> MessageHubContext { get; set; }
        IHubContext<ExecutionHab, IExecutionHab> ExecutionHabContext { get; set; }
        MessagesRepository MessagesRepository { get; set; }
        ProjectsRepository ProjectsRepository { get; set; }

        public AlgoExecutionService(IHostingEnvironment hostingEnvironment, IConfiguration configuration,
            IHubContext<MessageHub, IMessageHub> messageHubContext, IHubContext<ExecutionHab, IExecutionHab> executionHabContext,
            MessagesRepository messagesRepository, ProjectsRepository projectsRepository)
        {
            MessageHubContext = messageHubContext;
            ExecutionHabContext = executionHabContext;
            MessagesRepository = messagesRepository;
            ProjectsRepository = projectsRepository;

            ExecutionPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("AlgoExeDirectoryName").Value);
            if (!Directory.Exists(ExecutionPath))
                Directory.CreateDirectory(ExecutionPath);

            PytonExePath = configuration.GetSection("PytonExePath").Value;
            ClientUrl = configuration.GetSection("ClientUrl").Value;
        }

        public void Run(ProjectAlgoListEntity projectAlg, string executedBy)
        {
            if (projectAlg == null || (projectAlg.ProjectId == 0 && projectAlg.Algos.Count == 0))
                return;

            List<ExecutionInfoEntity> algoExecs = new List<ExecutionInfoEntity>();
            ExecutionInfoEntity firstAlgoExe;

            algoExecs = ProjectsRepository.SetAlgoExecutions(projectAlg, executedBy);
            firstAlgoExe = algoExecs.First();

            string resultPath = Path.Combine(ExecutionPath, string.Format("{0}_{1}", firstAlgoExe.ProjectId, firstAlgoExe.ProjectExecutionId));
            Directory.CreateDirectory(resultPath);

            string backgroundJobID = BackgroundJob.Enqueue(() => StartExecution(firstAlgoExe, executedBy, resultPath, true, algoExecs.Count == 1));

            if (algoExecs.Count > 1)
            {
                for (int i = 1; i < algoExecs.Count; i++)
                {
                    backgroundJobID= BackgroundJob.ContinueWith(backgroundJobID, () => StartExecution(algoExecs[i], executedBy, resultPath, false, i == algoExecs.Count - 1));
                }

                BackgroundJob.ContinueWith(backgroundJobID, () => FinishProjectExecution(executedBy, firstAlgoExe));
            }
        }

        public void StartExecution(ExecutionInfoEntity algoExe, string executedBy, string resultPath, bool isFirstExecution, bool isLastExecution)
        {
            var rootResultPath = resultPath;
            ProjectsRepository.StartAlgoExecution(algoExe.Id, isFirstExecution);
            SendStartExeMessage(executedBy, algoExe.AlgoName);
            ExecutionHabContext.Clients.All.Started(algoExe);

            if (algoExe.ProjectId != 0)
            {
                resultPath = Path.Combine(resultPath, string.Format("{0}_{1}", algoExe.Id, algoExe.AlgoId));
                Directory.CreateDirectory(resultPath);
            }

            string inputFilePath = Path.Combine(resultPath, "Input.csv");
            string outputFilePath = Path.Combine(resultPath, "Output.csv");

            CreateInputCsvFile(algoExe.ExeParams, inputFilePath);

            try
            {
                RunPyton(inputFilePath, outputFilePath, algoExe);
                SendEndExeMessage(executedBy, algoExe.AlgoName, algoExe.ProjectId > 0, resultPath);
            }

            catch(FileNotFoundException exp)
            {
                SendErrorExeMessage(algoExe, exp.Message, executedBy);
            }
            catch(AlgorithmExecutionException exp)
            {
                SendErrorExeMessage(algoExe, exp.Message, executedBy);
            }
            catch (Exception exp)
            {               
                SendErrorExeMessage(algoExe, $"General error on algorithm '{algoExe.AlgoName}' execution", executedBy);
            }
            finally
            {
                ProjectsRepository.EndAlgoExecution(algoExe.Id, rootResultPath, isLastExecution);
                ExecutionHabContext.Clients.All.Finished(algoExe.Id);
            }
        }

        private void CreateInputCsvFile(List<AlgoExecutionParamEntity> algoParams, string inputFilePath)
        {
            using (var writer = new StreamWriter(inputFilePath))
            {
                writer.WriteLine(string.Join(", ", algoParams.Select(p => p.Name)));
                writer.WriteLine(string.Join(", ", algoParams.Select(p => p.Value)));
            }
        }

        private void RunPyton(string inputFilePath, string outputFilePath, ExecutionInfoEntity algoExe)
        {
            var start = new ProcessStartInfo
            {
                FileName = PytonExePath,
                Arguments = string.Format("\"{0}\" \"{1}\" \"{2}\"", algoExe.FileExePath, inputFilePath, outputFilePath),
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException($@"Algorithm '{algoExe.AlgoName}' input file '{inputFilePath}' doesn't exist");

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                }
                if (process.ExitCode != 0)
                    throw new AlgorithmExecutionException(algoExe.AlgoName, process.ExitCode);
            }

            if (!File.Exists(outputFilePath))
                throw new FileNotFoundException($@"Algorithm '{algoExe.AlgoName}' output file '{outputFilePath}' doesn't exist");
        }

        private void SendStartExeMessage(string executedBy, string algoName)
        {
            var message = MessagesRepository.AddNewMessage("Start execution", $"Argotihm [{algoName}] execution is started by {executedBy}", executedBy);
            MessageHubContext.Clients.All.Send(message);
        }

        private void SendEndExeMessage(string executedBy, string algoName, bool isProjectExe, string rootPath)
        {
            string dirName = Path.GetFileName(rootPath);
            string link = string.Empty;

            if (!isProjectExe)
                link = $"Click <a href='{ClientUrl}/results/{dirName}'>here</a> to see results";

            var message = MessagesRepository.AddNewMessage("Execution results", $"Argotihm [{algoName}] finish execution. " + link, executedBy);
            MessageHubContext.Clients.All.Send(message);
        }

        private void SendErrorExeMessage(ExecutionInfoEntity executionInfo, string errorMessage, string executedBy)
        {
            ProjectsRepository.SetExecutionFailure(executionInfo.Id, errorMessage);
            var message = MessagesRepository.AddNewMessage("Execution error", errorMessage, executedBy);
            MessageHubContext.Clients.All.Send(message);
        }

        public void FinishProjectExecution(string executedBy, ExecutionInfoEntity firstAlgoExe)
        {
            var projectName = ProjectsRepository.GetProject(firstAlgoExe.ProjectId).Name;
            var message = MessagesRepository.AddNewMessage("Execution results", $"Project [{projectName}] finish execution.", executedBy);
            MessageHubContext.Clients.All.Send(message);
        }
    }

    public class AlgorithmExecutionException : Exception
    {
        public int ExitCode { get; }
        public string AlgorithmName { get; }

        public AlgorithmExecutionException(string algorithmName, int exitCode) 
            : base($@"Algorithm '{algorithmName}' execution failed. Exit code {exitCode}")
        {
            ExitCode = exitCode;
            AlgorithmName = algorithmName;
        }
    }
}
