using System;
using System.Collections.Generic;
using core;
using es.Aggregates;

namespace es
{
    public interface IEventStream : IImmutableList<IEvent>
    {
        void Add(Guid subject, string aggregate, string kind, string data, DateTimeOffset timestamp);
        IEnumerable<IEvent> Fetch(Guid subject);
        IEnumerable<IEvent> Fetch(Guid subject, DateTimeOffset timestampTo);
        IEnumerable<IEvent> Fetch(Guid subject, int sequenceTo);
    }
}
