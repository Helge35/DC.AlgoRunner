namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public string Desc { get; set; }
        [StringLength(250)]
        public string CreatedBy { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime LastExecutionDate { get; set; }
        public List<ExecutionInfo> ExecutionsList { get; set; }
        public List<Algorithm> AlgorithmsList { get; set; }
    }
}
