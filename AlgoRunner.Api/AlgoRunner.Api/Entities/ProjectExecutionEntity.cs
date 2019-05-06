using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class ProjectExecutionEntity
    {
        public int Id { get; set; }
        public string ExecutedBy { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ResultPath { get; set; }
        public List<ExecutionInfoEntity> ExecutionInfos { get; set; }
    }
}
