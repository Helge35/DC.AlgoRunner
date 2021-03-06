﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public class AlgoParamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public KeyValuePair<int, string> Type { get; set; }
        public List<string> Range { get; set; }
        public string Value { get; set; }
    }
}
