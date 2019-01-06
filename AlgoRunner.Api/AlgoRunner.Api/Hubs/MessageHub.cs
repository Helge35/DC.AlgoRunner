using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Hubs
{
    public class MessageHub : Hub<IMessageHub>
    {
        public Task SendAll(Message message)
        {
            return Clients.All.SendAll(message);
        }

        public Task Send(string user, Message message)
        {
            return Clients.User(user).Send(message);
        }

        //public override System.Threading.Tasks.Task OnConnectedAsync()
        //{
        //    var identity = "Oleg";
        //    Clients.Client(Context.ConnectionId).SendAll( new Message { Title = "Hello " + identity });
        //    return base.OnConnectedAsync();
        //}
    }
}
