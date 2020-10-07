using System.Collections.Generic;
using System.Threading.Tasks;
using microservice_arch.common;
using microservice_arch.servicelocator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace microservice_arch.servicelocator.Controllers
{
    [ApiController]
    public class ServiceLocatorController : ControllerBase
    {
        private readonly ILogger<ServiceLocatorController> logger;
        private readonly IServiceResolver resolver;
        private readonly IAuthenticationMetadataRetriever authenticationMetadataRetriever;


        public ServiceLocatorController(ILogger<ServiceLocatorController> logger,
            IServiceResolver resolver,
            IAuthenticationMetadataRetriever authenticationMetadataRetriever)
        {
            this.logger = logger;
            this.resolver = resolver;
            this.authenticationMetadataRetriever = authenticationMetadataRetriever;
        }

        [HttpGet]
        [Route("known-services")]
        public IEnumerable<Service> KnownServices() => this.resolver.ResolveAll();

        [HttpGet]
        [Route("auth-config")]
        public async Task<IActionResult> AuthConfig() => Content(await this.authenticationMetadataRetriever.Get(), "application/json");
    }
}
