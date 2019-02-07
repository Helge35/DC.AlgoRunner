using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Hubs
{
    public class ExecutionHab : Hub<IExecutionHab>
    {
        public Task Finished(int id)
        {
            return Clients.All.Finished(id);
        }

        public Task Started(ExecutionInfo exeInfo)
        {
            return Clients.All.Started(exeInfo);
        }
    }
}
