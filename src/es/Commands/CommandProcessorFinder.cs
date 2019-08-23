using System;

namespace es.Commands 
{
    public class CommandProcessorFinder : ICommandProcessorFinder
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandProcessorFinder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommandProcessor GetProcessor<T>() where T : ICommand
        {
            var type = typeof(T);
            var genericType = typeof(ICommandProcessor<T>);
            
            var specificType = genericType.MakeGenericType(type);

            return (ICommandProcessor<T>)_serviceProvider.GetService(specificType);
        }
    }
}