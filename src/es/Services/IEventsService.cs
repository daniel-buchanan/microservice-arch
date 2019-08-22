using System.Threading.Tasks;
using es;

namespace es.Services 
{
    public interface IEventsService 
    {
        Task Append(EventPayload @event);
    }
}