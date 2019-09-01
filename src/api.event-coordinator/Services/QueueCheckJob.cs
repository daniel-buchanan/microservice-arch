using System.Threading.Tasks;
using System.Linq;

namespace api.event_coordinator.Services 
{
    public class QueueCheckJob 
    {
        private readonly IQueue _queue;
        private readonly ISnapshotApi _snapshot;

        public QueueCheckJob(IQueue queue,
            ISnapshotApi snapshot)
        {
            _queue = queue;
            _snapshot = snapshot;
        }

        public async Task Run() 
        {
            var items = _queue.Fetch().ToList();
            await _snapshot.Update(items);
        }
    }
}