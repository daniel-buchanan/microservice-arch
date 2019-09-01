using System.Collections.Generic;
using System.Threading.Tasks;
using es;

namespace api.snapshot.Services 
{
    public class SnapshotUpdateService : ISnapshotUpdateService 
    {
        public Task Update(List<EventPayload> evnt) 
        {
            return Task.CompletedTask;
        }
    }
}