using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class DashboardInfoEntity
    {
        public IEnumerable<ProjectEntity> FavoriteList { get; set; }
        public IEnumerable<ProjectEntity> ResentList { get; set; }
        public IEnumerable<ProjectEntity> AllList { get; set; }
        public List<AlgorithmEntity> AlgorithmsList { get; set; }
        public IEnumerable<ExecutionInfoEntity> ExecutionInfoList { get; set; }

        public int ProjectsTotalSize { get; set; }
        public int AlgorithmsTotalSize { get; set; }
    }
}
