using microservice_arch.common;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace microservice_arch.servicelocator.Services
{
    public interface IAuthenticationMetadataRetriever
    {
        Task<string> Get();
    }

    public class AuthenticationMetadataRetriever : IAuthenticationMetadataRetriever
    {
        private readonly IServiceResolver resolver;
        private readonly IHttpClientFactory clientFactory;

        public AuthenticationMetadataRetriever(IServiceResolver resolver,
            IHttpClientFactory clientFactory)
        {
            this.resolver = resolver;
            this.clientFactory = clientFactory;
        }

        public async Task<string> Get()
        {
            var authenticatorService = this.resolver.ResolveAll().First(s => s.Key == Service.Authenticator);

            using var client = this.clientFactory.CreateClient();

            var authenticatorUri = new Uri(authenticatorService.Url);
            var url = new Uri(authenticatorUri, ".well-known/openid-configuration");
            var result = await client.GetStringAsync(url);
            return result;
        }
    }
}
