using core;
using Microsoft.AspNetCore.Mvc;
using api.authenticator.Services;
using System.Threading.Tasks;

namespace api.authenticator.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        private readonly IAuthenticatorService _authenticatorService;

        public CoreController(IAuthenticatorService authenticatorService)
        {
            _authenticatorService = authenticatorService;
        }

        // POST api/values
        [HttpPost]
        public async Task<AuthenticatorResponse> Post([FromBody] AuthenticatorRequest request)
        {
            return await _authenticatorService.Authenticate(request);
        }
    }
}
