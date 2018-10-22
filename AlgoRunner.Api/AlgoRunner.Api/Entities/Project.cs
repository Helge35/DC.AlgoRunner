using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class Project
    {
        public int Id{ get; set; }
        public Activity Activity { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CreatedBy { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime LastExecutionDate { get; set; }
        public List<ProjectExecution> ExecutionsList { get; set; }
        public List<Algorithm> AlgorithmsList { get; set; }
    }
}
