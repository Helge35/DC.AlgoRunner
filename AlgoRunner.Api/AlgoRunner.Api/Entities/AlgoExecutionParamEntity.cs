﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class AlgoExecutionParamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public dynamic Value { get; set; }
    }
}