using System;

namespace es.Aggregates
{
    public interface IAggregate
    {
        Guid Id { get; }
        int Version { get; }
    }
}
