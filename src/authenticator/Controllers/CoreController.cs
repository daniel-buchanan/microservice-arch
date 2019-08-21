using core;
using Microsoft.AspNetCore.Mvc;

namespace authenticator.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public AuthenticatorResponse Post([FromBody] AuthenticatorRequest request)
        {
            return null;
        }
    }
}
