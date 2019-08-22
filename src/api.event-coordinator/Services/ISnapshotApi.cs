using System.Threading.Tasks;
using Refit;
using es;

namespace api.event_coordinator.Services 
{
    public interface ISnapshotApi 
    {
        [Post("update")]
        Task Update(EventPayload evnt);
    }
}