using System.Threading.Tasks;
using Newtonsoft.Json;
using es;

namespace api.event_stream.Services
{
    public class EventsService : IEventsService 
    {
        private readonly ICoordinatorApi _coordinatorApi;
        private readonly IEventStream _eventStream;

        public EventsService(ICoordinatorApi coordinatorApi,
            IEventStream eventStream)
        {
            _coordinatorApi = coordinatorApi;
            _eventStream = eventStream;
        }

        public async Task Append(EventPayload evnt) 
        {
            var json = JsonConvert.SerializeObject(evnt.Data);

            _eventStream.Add(evnt.Subject,
                evnt.Aggregate,
                evnt.Kind,
                json,
                evnt.Timestamp);

            await _coordinatorApi.Publish(evnt);
        }
    }
}