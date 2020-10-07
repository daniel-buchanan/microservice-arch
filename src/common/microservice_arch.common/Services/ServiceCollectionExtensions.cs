using Microsoft.Extensions.DependencyInjection;

namespace microservice_arch.common.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IEnvironmentBase, EnvironmentBase>();
            return services;
        }
    }
}
