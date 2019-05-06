namespace AlgoRunner.Api.Dal.EF.Entities
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ProjectExecution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreMap]
        public int Id { get; set; }
        [StringLength(250)]
        public string ExecutedBy { get; set; }
        public int? ProjectId { get;  set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ResultPath { get; set; }

        public ICollection<ExecutionInfo> ExecutionInfos { get; set; }
    }
}