using System.Threading.Tasks;

namespace api.command_handler.Services 
{
    public interface ICommandHandlerService 
    {
        Task Handle(string json);
    }
}