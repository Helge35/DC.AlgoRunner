//namespace AlgoRunner.Api.Dal.EF.Entities
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;

//    public partial class DashboardInfo
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; }
//        public IEnumerable<Project> FavoriteList { get; set; }
//        public IEnumerable<Project> ResentList { get; set; }
//        public IEnumerable<Project> AllList { get; set; }
//        public List<Algorithm> AlgorithmsList { get; set; }
//        public IEnumerable<ExecutionInfo> ExecutionInfoList { get; set; }

//        public int ProjectsTotalSize { get; set; }
//        public int AlgorithmsTotalSize { get; set; }
//    }
//}
