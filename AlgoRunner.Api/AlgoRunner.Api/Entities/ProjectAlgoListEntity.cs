using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class ProjectAlgoListEntity
    {
        public int ProjectId { get; set; }
        public List<AlgorithmEntity> Algos { get; set; }
    }
}
