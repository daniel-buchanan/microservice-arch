namespace es.Commands 
{
    public interface ICommandProcessorFinder 
    {
        ICommandProcessor GetProcessor<T>() where T: ICommand;
    }
}