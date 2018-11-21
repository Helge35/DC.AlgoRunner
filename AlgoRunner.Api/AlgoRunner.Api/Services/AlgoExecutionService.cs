using AlgoRunner.Api.Entities;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
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
        public AlgoExecutionService(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            ExecutionPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("AlgoExeDirectoryName").Value);
            if (!Directory.Exists(ExecutionPath))
                Directory.CreateDirectory(ExecutionPath);

            PytonExePath = configuration.GetSection("PytonExePath").Value;
        }



        public string ExecutionPath { get; set; }
        public string PytonExePath { get; set; }

        public void Run(Algorithm algo)
        {
            string backgroundJobID = BackgroundJob.Enqueue(() => StartExecution(algo));
        }

        public void StartExecution(Algorithm algo)
        {
            string rootPath = Path.Combine(ExecutionPath, string.Format("{0}_{1}", algo.Id, DateTime.Now.Ticks));
            Directory.CreateDirectory(rootPath);

            string inputFilePath = Path.Combine(rootPath, "Input.csv");
            string outputFilePath = Path.Combine(rootPath, "Output.csv");

            CreateInputCsvFile(algo.AlgoParams, inputFilePath);
            string error = RunPyton(inputFilePath, outputFilePath, algo.FileServerPath);
        }

        private void CreateInputCsvFile(List<AlgoParam> algoParams, string inputFilePath)
        {
            using (var writer = new StreamWriter(inputFilePath))
            {
                writer.WriteLine(string.Join(", ", algoParams.Select(p => p.Name)));
                writer.WriteLine(string.Join(", ", algoParams.Select(p => p.Value)));
            }
        }

        private string RunPyton(string inputFilePath, string outputFilePath, string commangPath)
        {
            string standartError = string.Empty;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = PytonExePath;
            start.Arguments = string.Format("\"{0}\" \"{1}\" \"{2}\"", commangPath, inputFilePath, outputFilePath);
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    standartError = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    if (string.IsNullOrEmpty(standartError))
                        return standartError;
                    string result = reader.ReadToEnd();
                }
            }
            return standartError;
        }

    }
}
