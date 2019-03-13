using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Entities;

namespace AlgoRunner.Api.Services
{
    public static class ResultsFactory
    {
        /*
                new AlgResultType{Id = 1, Name="Text"},
                new AlgResultType{Id = 2, Name="Table"},
                new AlgResultType{Id = 3, Name="Lines Graph"},
                new AlgResultType{Id = 4, Name="Pie Graph"},
                new AlgResultType{Id = 5, Name="Bars Graph"},
                new AlgResultType{Id = 6, Name="Dotes Graph"},
             
             */
        internal static List<IAlgoResultEntity> GetResults(List<AlgorithmEntity> algos, string path)
        {
            var results = new List<IAlgoResultEntity>();
            foreach (var algo in algos)
            {
                results.Add(GetResult(algo, path));
            }
            return results;
        }

        internal static IAlgoResultEntity GetResult(AlgorithmEntity algo, string path)
        {
            IAlgoResultEntity result;
            result = new AlgoTextResultEntity();
            switch (algo.ResultType.Id)
            {
                case 1:
                    result = new AlgoTextResultEntity();
                    break;
                case 2:
                    result = new AlgoTableResultEntity();
                    break;
                //case 3:
                //    break;
                //case 4:
                //    break;
                //case 5:
                //    break;
                case 6:
                    result = new AlgoDotesResultEntity();
                    break;
                default:
                    return null;
            }

            var dirs = System.IO.Directory.GetDirectories(path);
            if (dirs.Length == 0)
            {
                path = path + @"\Output.csv";
            }
            else
            {
                foreach (var dir in dirs)
                {
                    if (dir.Split('_').Last() == algo.Id.ToString())
                    {
                        path = dir + @"\Output.csv";
                        break;
                    }
                }
            }

            result.ReadData(path);
            result.AlgoName = algo.Name;
            result.TypeId = algo.ResultType.Id;

            return result;
        }
    }
}
