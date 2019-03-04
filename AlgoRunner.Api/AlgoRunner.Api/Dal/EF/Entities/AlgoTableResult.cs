namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AlgoTableResult
    {
        [Key]
        public int Id { get; set; }
        public string AlgoName { get; set; }
        public int TypeId { get; set; }
        [NotMapped]
        public List<string> Titles { get; set; }
        [NotMapped]
        public List<string[]> Values { get; set; }        
    }
}
