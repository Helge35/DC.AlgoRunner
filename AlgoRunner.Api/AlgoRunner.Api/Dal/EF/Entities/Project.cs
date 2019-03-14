namespace AlgoRunner.Api.Dal.EF.Entities
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreMap]
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
        public List<ProjectAlgo> ProjectAlgoList { get; set; }

        [NotMapped]
        public List<Algorithm> AlgorithmsList
        {
            get
            {
                return ProjectAlgoList.Select(x => x.Algorithm).ToList();
            }
            set
            {
                ProjectAlgoList.Clear();
                foreach (var algorithm in value)
                {
                    ProjectAlgoList.Add(new ProjectAlgo
                    {
                        Project = this,
                        Algorithm = algorithm
                    });
                }                    
            }
        }

        public Project()
        {
            ExecutionsList = new List<ExecutionInfo>();
            ProjectAlgoList = new List<ProjectAlgo>();
        }
    }
}
