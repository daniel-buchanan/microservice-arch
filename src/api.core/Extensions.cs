using Microsoft.Extensions.DependencyInjection;

namespace api.core
{
    public static class Extensions
    {
        public static void AddApiFactory(this IServiceCollection services)
        {
            services.AddScoped<IApiFactory, ApiFactory>();
        }

        public static void AddApiService<T>(this IServiceCollection services, string baseUri) where T: class
        {
            services.AddScoped((provider) => provider.GetService<IApiFactory>().Get<T>(baseUri));
        }
    }
}
