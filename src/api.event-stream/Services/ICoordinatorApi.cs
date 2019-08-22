using Refit;
using System.Threading.Tasks;
using es;

namespace api.event_stream.Services
{
    public interface ICoordinatorApi 
    {
        [Post("publish")]
        Task Publish(EventPayload @event);
    }
}