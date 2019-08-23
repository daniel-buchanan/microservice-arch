using es.Commands;

namespace api.command_handler.Services
{
    public interface ICommandHandlerFinder 
    {
        ICommandHandler GetHandler<T>() where T: ICommand;
        ICommandHandler GetHandler(string type);
    }
}