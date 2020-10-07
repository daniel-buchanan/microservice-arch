using System.Collections.Generic;
using microservice_arch.common;
using microservice_arch.common.Services;

namespace microservice_arch.servicelocator.Services
{
    public interface IServiceResolver
    {
        bool TryGetFromEnvironment(string key, out Service service);
        IEnumerable<Service> ResolveAll();
    }

    public class ServiceResolver : IServiceResolver
    {
        private const string EnvPrefix = "SL";
        private const string EnvUrlSuffix = "URL";
        private const string EnvNameSuffix = "NAME";
        private const string EnvAuthSuffix = "AUTHREQ";

        private readonly IEnvironmentBase environment;

        public ServiceResolver(IEnvironmentBase environment)
        {
            this.environment = environment;
        }

        public bool TryGetFromEnvironment(string key, out Service service)
        {
            var url = this.environment.GetEnvironmentVariable($"{EnvPrefix}_{key?.ToUpper()}_{EnvUrlSuffix}");
            var name = this.environment.GetEnvironmentVariable($"{EnvPrefix}_{key?.ToUpper()}_{EnvNameSuffix}");
            var requiresAuthVal = this.environment.GetEnvironmentVariable($"{EnvPrefix}_{key?.ToUpper()}_{EnvAuthSuffix}");

            if (string.IsNullOrWhiteSpace(url) ||
                string.IsNullOrWhiteSpace(name))
            {
                service = null;
                return false;
            }

            bool.TryParse(requiresAuthVal, out var requiresAuth);

            service = Service.FromUrl(url).WithKey(key).WithName(name);
            if (requiresAuth) service.RequiresAuthentication();

            return true;
        }

        public IEnumerable<Service> ResolveAll()
        {
            yield return Service.FromUrl("http://169.254.100.2").WithKey(Service.ServiceLocator).WithName("Service Locator");

            if (TryGetFromEnvironment(Service.Authenticator, out var a)) yield return a;
            if (TryGetFromEnvironment(Service.Authorization, out var aa)) yield return aa;
            if (TryGetFromEnvironment(Service.Farms, out var f)) yield return f;
            if (TryGetFromEnvironment(Service.Animals, out var an)) yield return an;
            if (TryGetFromEnvironment(Service.Processing, out var proc)) yield return proc;
        }
    }
}
