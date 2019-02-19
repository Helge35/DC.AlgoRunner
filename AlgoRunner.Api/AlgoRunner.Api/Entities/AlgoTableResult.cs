using System;
using System.Collections.Generic;
using System.IO;

namespace AlgoRunner.Api.Entities
{
    public class AlgoTableResult : IAlgoResult
    {
        public string AlgoName { get; set; }
        public int TypeId { get; set; }

        public List<string> Titles { get; set; }
        public List<string[]> Values { get; set; }


        public void ReadData(string path)
        {
            Titles = new List<string>();
            using (var reader = new StreamReader(path))
            {
                var titleLine = reader.ReadLine();
                var titles = titleLine.Split(',');

                for (int i = 0; i < titles.Length;i++)
                {
                    Titles.Add(titles[i]);
                }

                Values = new List<string[]>();
                while (!reader.EndOfStream)
                {
                    string[] row = new string[titles.Length];
                    var line = reader.ReadLine();
                    Values.Add(line.Split(','));
                }
            }
        }
    }
}
