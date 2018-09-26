using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class Project
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime LastExecutionDate { get; set; }
    }
}
