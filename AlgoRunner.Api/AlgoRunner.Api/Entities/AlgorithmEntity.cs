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
        public ActivityEntity Activity { get; set; }
        public string CreatedBy { get; set; }
        public AlgResultTypeEntity ResultType { get; set; }
        public List<AlgoParamEntity> AlgoParams { get; set; }
        public string FileServerPath { get; set; }
    }
}
