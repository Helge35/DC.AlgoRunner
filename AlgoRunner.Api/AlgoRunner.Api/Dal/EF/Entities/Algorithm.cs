namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Algorithm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public string Desc { get; set; }
        public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
        public string CreatedBy { get; set; }       
        public int ResultTypeId { get; set; }
        [ForeignKey("ResultTypeId")]
        public AlgResultType ResultType { get; set; }
        public List<AlgoParam> AlgoParams { get; set; }
        [StringLength(1000)]
        public string FileServerPath { get; set; }
    }
}
