namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ProjectAlgoList
    {
        [Key]
        public int ProjectId { get; set; }
        public List<Algorithm> Algos { get; set; }
    }
}
