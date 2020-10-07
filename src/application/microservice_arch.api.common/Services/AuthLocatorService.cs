using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace microservice_arch.api.common.Services
{
    public interface IAuthLocatorService
    {
        Task<OpenIdConfiguration> GetOpenIdConfiguration();
    }

    public class AuthLocatorService : IAuthLocatorService
    {
        private const int NumberOfRetries = 5;
        private const int WaitTime = 500;
        private readonly string ServiceLocatorUrl = "http://servicelocator/auth-config";
        private readonly IHttpClientFactory clientFactory;

        public AuthLocatorService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<OpenIdConfiguration> GetOpenIdConfiguration() => await Get();

        private async Task<OpenIdConfiguration> Get(int count = 0)
        {
            try
            {
                Console.WriteLine("AuthLocator :: Attempt {0} to get OpenId Configuration", count + 1);
                using var client = this.clientFactory.CreateClient();

                var authenticatorUri = new Uri(ServiceLocatorUrl);
                var response = await client.GetAsync(authenticatorUri);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (count >= NumberOfRetries)
                    {
                        Console.WriteLine("AuthLocator :: Failed to retrieve Configuration");
                        return null;
                    }

                    await Task.Delay(WaitTime);
                    return await Get(count + 1);
                }

                Console.WriteLine("AuthLocator :: Retrieved Configuration Successfully");

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OpenIdConfiguration>(content);
            }
            catch (Exception e)
            {
                if (count >= NumberOfRetries) return null;
                await Task.Delay(WaitTime);
                return await Get(count + 1);
            }
        }
    }
}
