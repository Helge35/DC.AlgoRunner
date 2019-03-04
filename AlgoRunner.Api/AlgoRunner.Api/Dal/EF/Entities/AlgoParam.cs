namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AlgoParam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [NotMapped]
        public KeyValuePair<int, string> Type { get; set; }
        [NotMapped]
        public List<string> Range { get; set; }
        [StringLength(1000)]
        public string Value { get; set; }
    }
}
