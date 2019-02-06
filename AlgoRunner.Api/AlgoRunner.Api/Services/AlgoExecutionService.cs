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
        public AlgoExecutionService(IHostingEnvironment hostingEnvironment, IConfiguration configuration, IHubContext<MessageHub, IMessageHub> messageHubContext, MessagesRepository messagesRepository)
        {
            MessageHubContext = messageHubContext;
            MessagesRepository = messagesRepository;

            ExecutionPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("AlgoExeDirectoryName").Value);
            if (!Directory.Exists(ExecutionPath))
                Directory.CreateDirectory(ExecutionPath);

            PytonExePath = configuration.GetSection("PytonExePath").Value;
            ClientUrl = configuration.GetSection("ClientUrl").Value;
        }

        string ExecutionPath { get; set; }
        string PytonExePath { get; set; }
        string ClientUrl { get; set; }
        string BackgroundJobID { get; set; }
        IHubContext<MessageHub, IMessageHub> MessageHubContext { get; set; }
        MessagesRepository MessagesRepository { get; set; }

        public void Run(Algorithm[] algos, string executedBy)
        {
            if (algos.Length == 0)
                return;

            var firstAlgo = algos.First();
            SendStartExeMessage(executedBy, firstAlgo.Name);
            BackgroundJobID = BackgroundJob.Enqueue(() => StartExecution(firstAlgo, executedBy));

            if (algos.Length > 1)
            {
                for (int i = 1; i < algos.Length; i++)
                {
                    BackgroundJob.ContinueWith(BackgroundJobID, () => StartExecution(algos[i], executedBy));
                }
            }
        }

        public void StartExecution(Algorithm algo, string executedBy)
        {
            string rootPath = Path.Combine(ExecutionPath, string.Format("{0}_{1}", algo.Id, DateTime.Now.Ticks));
            Directory.CreateDirectory(rootPath);

            string inputFilePath = Path.Combine(rootPath, "Input.csv");
            string outputFilePath = Path.Combine(rootPath, "Output.csv");

            CreateInputCsvFile(algo.AlgoParams, inputFilePath);

            try
            {
                RunPyton(inputFilePath, outputFilePath, algo.FileServerPath);
                SendEndExeMessage(executedBy, algo.Name, rootPath);
            }

            catch (Exception ex)
            {
                SendErrorExeMessage(executedBy, algo.Name, rootPath);
            }
        }

        private void CreateInputCsvFile(List<AlgoParam> algoParams, string inputFilePath)
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
