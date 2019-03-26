namespace AlgoRunner.Api.Dal.EF.Entities
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreMap]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }        
        public bool IsAdmin { get; set; }
        public List<UserFavoriteProject> UserFavoriteProjectList { get; set; }
    }
}
