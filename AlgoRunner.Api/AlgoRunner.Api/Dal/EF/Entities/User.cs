namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }
        public bool IsAdmin { get; set; }
    }
}
