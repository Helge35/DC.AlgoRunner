using AlgoRunner.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Hubs
{
    public interface IExecutionHab
    {
        Task Finished(int exeID);
        Task Started(ExecutionInfo exeInfo);
    }
}
