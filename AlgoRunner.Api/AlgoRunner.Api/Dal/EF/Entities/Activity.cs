namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Activity
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string ServerPath { get; set; }
    }
}
