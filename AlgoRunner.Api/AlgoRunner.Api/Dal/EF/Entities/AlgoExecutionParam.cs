namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class AlgoExecutionParam
    {
        public int ID { get; set; }

        public int? ExecutionInfoID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Value { get; set; }

        public virtual ExecutionInfo ExecutionInfo { get; set; }
    }
}
