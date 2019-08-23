using api.command_handler.Services.Processors;
using api.command_handler.Services.Validators;
using es.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace api.command_handler.Services 
{
    public static class Registry 
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            services.AddScoped<ICommandProcessorFinder, CommandProcessorFinder>();
            services.AddScoped<ICommandValidator<AnimalsArrivedCommand>, AnimalsArrivedCommandValidator>();
            services.AddScoped<ICommandHandler<AnimalsArrivedCommand>, AnimalsArrivedCommandHandler>();
            services.AddScoped<ICommandHandlerService, CommandHandlerService>();
        }
    }
}