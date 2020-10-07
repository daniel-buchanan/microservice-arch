using System;
using System.Collections.Generic;
using microservice_arch.common.auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = microservice_arch.authorization.Services.IAuthorizationService;

namespace microservice_arch.authorization.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService authorization;

        public AuthorizationController(IAuthorizationService authorization)
        {
            this.authorization = authorization;
        }

        [HttpGet]
        [Authorize]
        [Route("current")]
        public User Current()
        {
            return new User();
        }

        [HttpPost]
        [Authorize]
        [Route("is-authorized")]
        public AuthorizationResponse IsAuthorized([FromBody] AuthorizationRequest request) => this.authorization.Authorize(request);

        [HttpGet]
        [Authorize]
        [Route("requests")]
        public IEnumerable<AuthorizationResponse> Requests(TimeSpan? over = null)
        {
            return this.authorization.GetAuthorizations(Guid.Empty, over);
        }
    }
}
