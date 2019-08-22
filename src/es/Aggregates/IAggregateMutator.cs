namespace es.Aggregates
{
    public interface IAggregateMutator<T> where T: IAggregate
    {
        T Mutate(T currentState, IEvent @event);
    }
}
