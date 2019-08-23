using System.Threading.Tasks;
using es.Commands;
using Newtonsoft.Json;

namespace api.command_handler.Services 
{
    public class CommandHandlerService : ICommandHandlerService
    {
        private readonly ICommandHandlerFinder _commandHandlerFinder;

        public CommandHandlerService(ICommandHandlerFinder commandHandlerFinder)
        {
            _commandHandlerFinder = commandHandlerFinder;
        }

        public async Task Handle(string json)
        {
            var genericCommand = JsonConvert.DeserializeObject<Command>(json);
            
            var handler = _commandHandlerFinder.GetHandler(genericCommand.CommandType);

            if(handler == null) return;

            var command = Command.FromType(json);
            await handler.Process(command);
        }
    }
}