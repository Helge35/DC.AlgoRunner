using System;
using System.Collections.Generic;

namespace AlgoRunner.Api.Entities
{
    public class ExecutionInfoEntity
    {
        public int Id { get; set; }
        public int ProjectExecutionId { get; set; }
        public int AlgoId { get; set; }
        public int ProjectId { get; set; }
        public string AlgoName { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ExecutedBy {get;set;}
        public List<AlgoExecutionParamEntity> ExeParams { get; set; }
        public string FileExePath { get; set; }
        public ExecutionResult ExecutionResult { get; set; }
        public string FailureReason { get; set; }
    }

    public enum ExecutionResult
    {
        Success,
        PartialSuccess,
        Failure,
        Pending
    }
}
