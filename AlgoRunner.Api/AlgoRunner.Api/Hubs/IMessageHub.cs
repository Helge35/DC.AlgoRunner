using AlgoRunner.Api.Entities;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Hubs
{
    public interface IMessageHub
    {
        Task SendAll(Message message);
        Task Send( Message message);
    }
}
