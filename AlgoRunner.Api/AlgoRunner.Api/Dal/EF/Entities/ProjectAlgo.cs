namespace AlgoRunner.Api.Dal.EF.Entities
{
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ProjectAlgo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreMap]
        public int Id { get; set; }
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int AlgoId { get; set; }
        [ForeignKey("AlgoId")]
        public Algorithm Algorithm { get; set; }
    }
}
