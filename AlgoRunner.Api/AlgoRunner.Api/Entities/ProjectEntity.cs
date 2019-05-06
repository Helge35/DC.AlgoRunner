using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class ProjectEntity
    {
        public int Id{ get; set; }
        public ActivityEntity Activity { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CreatedBy { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime LastExecutionDate { get; set; }
        public List<ProjectExecutionEntity> ProjectExecutions { get; set; }
        public List<AlgorithmEntity> AlgorithmsList { get; set; }

        public ProjectEntity()
        {
            ProjectExecutions = new List<ProjectExecutionEntity>();
            AlgorithmsList = new List<AlgorithmEntity>();
        }
    }
}
