using System;

namespace es
{
    public interface IAggregate
    {
        Guid Id { get; }
        int Version { get; }
    }
}
