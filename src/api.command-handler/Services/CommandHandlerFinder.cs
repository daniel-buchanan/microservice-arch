using System;
using System.Linq;
using System.Reflection;
using es.Commands;

namespace api.command_handler.Services
{
    public class CommandHandlerFinder : ICommandHandlerFinder
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandHandlerFinder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private ICommandHandler GetHandler(Type type) 
        {
            if(type == null) return null;

            var genericType = typeof(ICommandHandler<>);
            
            var specificType = genericType.MakeGenericType(type);

            return (ICommandHandler)_serviceProvider.GetService(specificType);
        }

        public ICommandHandler GetHandler<T>() where T : ICommand => GetHandler(typeof(T));

        public ICommandHandler GetHandler(string type)
        {
            var assembly = Assembly.Load("es");
            var foundType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            return GetHandler(foundType);
        }
    }
}