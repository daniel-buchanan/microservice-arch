using System.Threading.Tasks;
using Refit;
using es;
using System.Collections.Generic;

namespace api.event_coordinator.Services 
{
    public interface ISnapshotApi 
    {
        [Post("update")]
        Task Update(List<EventPayload> evnt);
    }
}