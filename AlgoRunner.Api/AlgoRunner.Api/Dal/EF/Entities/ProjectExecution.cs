namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class ProjectExecution
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string ExecutedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ResultPath { get; set; }
    }
}
