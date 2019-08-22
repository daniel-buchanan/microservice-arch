using System;

namespace es.Aggregates
{
    public interface IAggregatePlayer<T> where T: IAggregate
    {
        T PlayTo(Guid subjectId, DateTimeOffset timestamp);
        T PlayTo(Guid subjectId, int sequence);
        T PlayToNow(Guid subjectId);
    }
}
