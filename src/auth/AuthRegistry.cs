using api.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace auth
{
    public static class AuthRegistry
    {
        public static void RegisterServices(IServiceCollection services, string baseUri)
        {
            services.AddApiService<IAuthenticatorService>(baseUri);
        }

        public static void RegisterFilters(MvcOptions mvc)
        {
            RegisterFilters(mvc.Filters);
        }

        public static void RegisterFilters(FilterCollection filters)
        {
            filters.Add<AuthActionFilter>();
        }
    }
}
