namespace AlgoRunner.Api.Dal.EF.Entities
{
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserFavoriteProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreMap]
        public int Id { get; set; }
        public User User { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [NotMapped]
        public int UserId
        {
            get
            {
                return User != null ? User.Id : 0;
            }
        }
    }
}
