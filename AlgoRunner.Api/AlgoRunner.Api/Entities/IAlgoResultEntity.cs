using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Entities
{
    public interface IAlgoResultEntity
    {
        string AlgoName { get; set; }
        int TypeId { get; set; }


        void ReadData(string path);
    }
}
