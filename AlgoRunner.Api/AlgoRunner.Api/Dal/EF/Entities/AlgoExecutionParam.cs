namespace AlgoRunner.Api.Dal.EF.Entities
{
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AlgoExecutionParam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreMap]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }       
        [StringLength(1000)]
        public string Value { get; set; }
    }
}
