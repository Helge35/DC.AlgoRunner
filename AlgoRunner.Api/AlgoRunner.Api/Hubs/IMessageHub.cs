using AlgoRunner.Api.Entities;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Hubs
{
    public interface IMessageHub
    {
        Task SendAll(MessageEntity message);
        Task Send( MessageEntity message);
    }
}
