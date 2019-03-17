namespace AlgoRunner.Api.Dal.EF.Entities
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ExecutionInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreMap]
        public int Id { get; set; }        
        public int AlgoId { get; set; }
        [ForeignKey("AlgoId")]
        public Algorithm Algorithm { get; set; }          
        public Project Project { get; set; }                
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [StringLength(250)]
        public string ExecutedBy { get; set; }
        public List<AlgoExecutionParam> ExeParams { get; set; }
        [StringLength(1000)]
        public string FileExePath { get; set; }

        [NotMapped]
        public int ProjectExecutionId { get { return Id; } }

        [NotMapped]
        public string AlgoName
        {
            get
            {
                return Algorithm?.Name;
            }
            set
            {
                if (Algorithm != null)
                    Algorithm.Name = value;
            }
        }

        [NotMapped]
        public int ProjectId
        {
            get
            {
                return Project != null ? Project.Id : int.MinValue;
            }            
        }

        [NotMapped]
        public string ProjectName
        {
            get
            {
                return Project?.Name;
            }
            set
            {
                if (Project != null)
                    Project.Name = value;
            }
        }
    }
}
