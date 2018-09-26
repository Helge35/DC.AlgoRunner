using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class DashboardInfo
    {
        public IEnumerable<Project> FavoriteList { get; set; }
        public IEnumerable<Project> ResentList { get; set; }
        public IEnumerable<Project> AllList { get; set; }
    }
}
