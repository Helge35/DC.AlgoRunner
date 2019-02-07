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
        string BackgroundJobID { get; set; }
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

        public void Run(List<ExecutionInfo> algoExecs, string executedBy)
        {
            if (algoExecs.Count == 0)
                return;

            var firstAlgoExe = algoExecs.First();
            BackgroundJobID = BackgroundJob.Enqueue(() => StartExecution(firstAlgoExe, executedBy));

            if (algoExecs.Count > 1)
            {
                for (int i = 1; i < algoExecs.Count; i++)
                {
                    BackgroundJob.ContinueWith(BackgroundJobID, () => StartExecution(algoExecs[i], executedBy));
                }
            }
        }

        public void StartExecution(ExecutionInfo algoExe, string executedBy)
        {
            SendStartExeMessage(executedBy, algoExe.AlgoName);
            ExecutionHabContext.Clients.All.Started(algoExe);
            string rootPath = Path.Combine(ExecutionPath, string.Format("{0}_{1}", algoExe.Id, DateTime.Now.Ticks));
            Directory.CreateDirectory(rootPath);

            string inputFilePath = Path.Combine(rootPath, "Input.csv");
            string outputFilePath = Path.Combine(rootPath, "Output.csv");

            CreateInputCsvFile(algoExe.ExeParams, inputFilePath);

            try
            {
                RunPyton(inputFilePath, outputFilePath, algoExe.FileExePath);
                SendEndExeMessage(executedBy, algoExe.AlgoName, rootPath);
            }

            catch (Exception ex)
            {
                SendErrorExeMessage(executedBy, algoExe.AlgoName, rootPath);
            }
            finally
            {
                ProjectsRepository.EndAlgoExecution(algoExe.Id);
                ExecutionHabContext.Clients.All.Finished(algoExe.Id);
            }
        }

        private void CreateInputCsvFile(List<AlgoExecutionParams> algoParams, string inputFilePath)
        {
            using (var writer = new StreamWriter(inputFilePath))
            {
                writer.WriteLine(string.Join(", ", algoParams.Select(p => p.Name)));
                writer.WriteLine(string.Join(", ", algoParams.Select(p => p.Value)));
            }
        }

        private void RunPyton(string inputFilePath, string outputFilePath, string commandPath)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = PytonExePath;
            start.Arguments = string.Format("{0} {1} {2}", commandPath, inputFilePath, outputFilePath);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                }
            }
        }

        private void SendStartExeMessage(string executedBy, string algoName)
        {
            var message = MessagesRepository.AddNewMessage("Start execution", $"Argotihm [{algoName}] execution is started by {executedBy}", executedBy);
            MessageHubContext.Clients.All.Send(message);
        }

        private void SendEndExeMessage(string executedBy, string algoName, string rootPath)
        {
            string link = Path.GetFileName(rootPath);

            var message = MessagesRepository.AddNewMessage("Execution results", $"Argotihm [{algoName}] finish execution. Click <a href='{ClientUrl}/results/{link}'>here</a> to see results", executedBy);
            MessageHubContext.Clients.All.Send(message);
        }

        private void SendErrorExeMessage(string executedBy, string algoName, string rootPath)
        {
            var message = MessagesRepository.AddNewMessage("Error execution", $"Error on execution [{algoName}]" , executedBy);
            MessageHubContext.Clients.All.Send(message);
        }
    }
}
