namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Message
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime CreateDate { get; set; }
        public bool isReaded { get; set; }
    }
}
