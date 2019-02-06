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
        public List<Algorithm> AlgorithmsList { get; set; }
        public IEnumerable<ExecutionInfo> ExecutionInfoList { get; set; }

        public int ProjectsTotalSize { get; set; }
        public int AlgorithmsTotalSize { get; set; }
    }
}
