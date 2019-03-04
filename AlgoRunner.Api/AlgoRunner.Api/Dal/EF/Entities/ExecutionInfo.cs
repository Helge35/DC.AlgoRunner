namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ExecutionInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectExecutionId { get; set; }
        public int AlgoId { get; set; }
        public int ProjectId { get; set; }
        public string AlgoName { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [StringLength(250)]
        public string ExecutedBy { get; set; }
        public List<AlgoExecutionParam> ExeParams { get; set; }
        [StringLength(1000)]
        public string FileExePath { get; set; }
    }
}
