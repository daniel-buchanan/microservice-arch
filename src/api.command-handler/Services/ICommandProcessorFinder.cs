using es.Commands;

namespace api.command_handler.Services
{
    public interface ICommandProcessorFinder 
    {
        ICommandHandler GetProcessor<T>() where T: ICommand;
    }
}