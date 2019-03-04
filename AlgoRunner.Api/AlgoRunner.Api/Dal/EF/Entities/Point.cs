namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Point
    {
        [Key]
        public int Id { get; set; }
        public float X { get; set; }
        public float Y{ get; set; }
    }
}
