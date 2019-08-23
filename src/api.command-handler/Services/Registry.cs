using api.command_handler.Services.Handlers;
using api.command_handler.Services.Validators;
using es.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace api.command_handler.Services 
{
    public static class Registry 
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            services.AddScoped<ICommandHandlerFinder, CommandHandlerFinder>();
            services.AddScoped<ICommandValidator<AnimalsArrivedCommand>, AnimalsArrivedCommandValidator>();
            services.AddScoped<ICommandHandler<AnimalsArrivedCommand>, AnimalsArrivedCommandHandler>();
            services.AddScoped<ICommandHandlerService, CommandHandlerService>();
        }
    }
}