using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class AdminInfo
    {
        public List<User> Members { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
