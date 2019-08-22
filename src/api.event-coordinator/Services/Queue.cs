using System.Collections.Generic;
using es;

namespace api.event_coordinator.Services 
{
    public interface IQueue 
    {
        void Add(EventPayload evnt);
        IEnumerable<EventPayload> Fetch();
    }

    public class Queue : IQueue
    {
        private readonly List<EventPayload> Items = new List<EventPayload>();

        public void Add(EventPayload evnt) 
        {
            Items.Add(evnt);
        }

        public IEnumerable<EventPayload> Fetch() 
        {
            var copied = new EventPayload[Items.Count];
            Items.CopyTo(copied);
            Items.Clear();
            return copied;
        }
    }
}