using System.Collections.Generic;
using System.Threading.Tasks;
using es;

namespace api.snapshot.Services 
{
    public interface ISnapshotUpdateService 
    {
        Task Update(List<EventPayload> evnt);
    }
}