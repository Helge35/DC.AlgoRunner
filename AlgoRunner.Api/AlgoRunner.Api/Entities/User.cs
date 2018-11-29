﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }
        public bool IsAdmin { get; set; }
    }
}