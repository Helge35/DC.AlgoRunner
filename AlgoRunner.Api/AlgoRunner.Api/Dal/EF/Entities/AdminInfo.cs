namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AdminInfo
    {
        [Key]
        public int Id { get; set; }
        public List<User> Members { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
