using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class AdminInfoEntity
    {
        public List<UserEntity> Members { get; set; }
        public List<ActivityEntity> Activities { get; set; }
    }
}
