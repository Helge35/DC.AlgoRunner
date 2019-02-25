using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class AlgorithmEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public Activity Activity { get; set; }
        public string CreatedBy { get; set; }
        public AlgResultType ResultType { get; set; }
        public List<AlgoParam> AlgoParams { get; set; }
        public string FileServerPath { get; set; }
    }
}
