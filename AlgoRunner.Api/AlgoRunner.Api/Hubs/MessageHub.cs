using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Hubs
{
    public class MessageHub : Hub<IMessageHub>
    {
        public Task Send(Message message)
        {
            return Clients.All.Send( message);
        }
    }
}
