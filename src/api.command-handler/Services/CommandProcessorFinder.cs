using System;
using es.Commands;

namespace api.command_handler.Services
{
    public class CommandProcessorFinder : ICommandProcessorFinder
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandProcessorFinder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommandHandler GetProcessor<T>() where T : ICommand
        {
            var type = typeof(T);
            var genericType = typeof(ICommandHandler<T>);
            
            var specificType = genericType.MakeGenericType(type);

            return (ICommandHandler<T>)_serviceProvider.GetService(specificType);
        }
    }
}