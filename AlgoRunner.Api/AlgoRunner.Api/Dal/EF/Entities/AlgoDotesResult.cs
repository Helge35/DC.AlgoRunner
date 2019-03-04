namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AlgoDotesResult
    {
        [Key]
        public int Id { get; set; }
        public string AlgoName { get; set; }
        public int TypeId { get; set; }

        public List<ResultCategory> Categories { get; set; }        
    }
}
