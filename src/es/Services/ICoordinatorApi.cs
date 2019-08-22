using Refit;
using System.Threading.Tasks;

namespace es.Services 
{
    public interface ICoordinatorApi 
    {
        [Post("publish")]
        Task Publish(EventPayload @event);
    }
}