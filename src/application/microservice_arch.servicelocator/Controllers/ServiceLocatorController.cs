using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservice_arch.common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace microservice_arch.servicelocator.Controllers
{
    [ApiController]
    public class ServiceLocatorController : ControllerBase
    {
        private readonly ILogger<ServiceLocatorController> logger;

        public ServiceLocatorController(ILogger<ServiceLocatorController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("known-services")]
        public IEnumerable<Service> KnownServices()
        {
            yield return Service.FromUrl("http://196.70.121.2").WithName("Service Locator");
            yield return Service.FromUrl("http://196.70.121.3").WithName("Authenticator");
            yield return Service.FromUrl("http://196.70.121.4").WithName("Authorization").RequiresAuthentication();
            yield return Service.FromUrl("http://196.70.121.5").WithName("Farms").RequiresAuthentication();
            yield return Service.FromUrl("http://196.70.121.6").WithName("Animals").RequiresAuthentication();
        }
    }
}
