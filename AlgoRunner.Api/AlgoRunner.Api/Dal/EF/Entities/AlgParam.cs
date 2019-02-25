namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class AlgParam
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Value { get; set; }

        public int? AlgExecutionParamTypeID { get; set; }

        public string Range { get; set; }

        public virtual AlgParamType AlgParamType { get; set; }
    }
}
