using System;
using System.Collections.Generic;
using System.IO;

namespace AlgoRunner.Api.Entities
{
    public class AlgoDotesResult
    {
        public string AlgoName { get; set; }
        public int TypeId { get; set; }
        public List<ResultCategory> Categories { get; set; }

        internal void ReadDataFromFile(string path)
        {
            Categories = new List<ResultCategory>();
            using (var reader = new StreamReader(path))
            {
                var titleLine = reader.ReadLine();
                var titles = titleLine.Split(',');

                for (int i = 0; i < titles.Length;)
                {
                    Categories.Add(new ResultCategory { Label = titles[i], Data = new List<Point>() });
                    i = i + 2;
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    for (int i = 0; i < values.Length;)
                    {
                        int categoryInd = i == 0 ? 0 : i / 2;
                        if(!string.IsNullOrEmpty(values[i].Trim()) && !string.IsNullOrEmpty(values[i+1].Trim()))
                            Categories[categoryInd].Data.Add(new Point { X = float.Parse(values[i]), Y = float.Parse(values[i + 1]) });
                        i = i + 2;
                    }
                }
            }
        }
    }
}
