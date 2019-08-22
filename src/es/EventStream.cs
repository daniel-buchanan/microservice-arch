using System;
using System.Collections.Generic;
using System.Linq;
using core;

namespace es
{
    public class EventStream : ImmutableList<IEvent>, IEventStream
    {
        private int _nextSequence = 0;

        public void Add(Guid subject, string aggregate, string kind, string data, DateTimeOffset timestamp)
        {
            var nextSequence = _nextSequence + 1;
            var @event = new Event(nextSequence, subject, aggregate, kind, data, timestamp);
            base.Add(@event);
            _nextSequence = nextSequence;
        }

        public IEnumerable<IEvent> Fetch<T>(Guid subject) where T : IAggregate
        {
            return this.Where(e => e.Subject == subject).OrderBy(e => e.Sequence);
        }

        public IEnumerable<IEvent> Fetch<T>(Guid subject, DateTime timestampTo) where T : IAggregate
        {
            return Fetch<T>(subject).Where(e => e.Timestamp <= timestampTo);
        }

        public IEnumerable<IEvent> Fetch<T>(Guid subject, int sequenceTo) where T : IAggregate
        {
            return Fetch<T>(subject).Where(e => e.Sequence <= sequenceTo);
        }
    }
}
