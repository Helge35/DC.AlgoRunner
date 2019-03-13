namespace AlgoRunner.Api.Dal.EF.Entities
{
   using System.ComponentModel.DataAnnotations;

    public partial class Role
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
    }
}
