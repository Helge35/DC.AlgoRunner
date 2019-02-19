using System;
using System.Collections.Generic;
using System.IO;

namespace AlgoRunner.Api.Entities
{
    public class AlgoTextResult : IAlgoResult
    {
        public string AlgoName { get; set; }
        public int TypeId { get; set; }

        public List<string> Titles { get; set; }
        public List<string[]> Values { get; set; }

        public void ReadData(string path)
        {
            Titles = new List<string>();
            Values = new List<string[]>();
            using (var reader = new StreamReader(path))
            {
                Titles.Add(reader.ReadLine());
                Values.Add(new string[] { reader.ReadLine() });
            }
        }
    }
}
