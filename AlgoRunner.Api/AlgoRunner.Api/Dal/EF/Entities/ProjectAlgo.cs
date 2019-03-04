namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ProjectAlgo
    {
        [Key]
        public int Id { get; set; }       
        public int ProjectId { get; set; }       
        public int AlgoId { get; set; }
    }
}
