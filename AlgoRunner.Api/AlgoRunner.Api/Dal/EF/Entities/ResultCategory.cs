namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ResultCategory
    {
        [Key]
        [StringLength(250)]
        public string Label { get; set; }
        public List<Point> Data { get; set; }
    }
}
