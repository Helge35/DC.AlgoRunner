using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class ProjectAlgoList
    {
        public int ProjectId { get; set; }
        public List<Algorithm> Algos { get; set; }
    }
}
