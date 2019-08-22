using System.Threading.Tasks;
using es;

namespace api.event_stream.Services
{
    public interface IEventsService 
    {
        Task Append(EventPayload @event);
    }
}