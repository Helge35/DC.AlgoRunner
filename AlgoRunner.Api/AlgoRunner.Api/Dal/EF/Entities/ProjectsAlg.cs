namespace AlgoRunner.Api.Dal.EF.Entities
{
    public partial class ProjectsAlg
    {
        public int ID { get; set; }

        public int? ProjectID { get; set; }

        public int? AlgoID { get; set; }

        public virtual Algorithm Algorithm { get; set; }

        public virtual Project Project { get; set; }
    }
}
