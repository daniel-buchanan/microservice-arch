using System;
using System.Collections.Generic;
using microservice_arch.common.auth;

namespace microservice_arch.authorization.Services
{
    public interface IAuthorizationService
    {
        AuthorizationResponse Authorize(AuthorizationRequest request);
        IEnumerable<AuthorizationResponse> GetAuthorizations(Guid subject, TimeSpan? span = null);
    }

    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationCache cache;

        public AuthorizationService(IAuthorizationCache cache)
        {
            this.cache = cache;
        }

        public AuthorizationResponse Authorize(AuthorizationRequest request)
        {
            if (this.cache.Exists(request) && !this.cache.IsExpired(request))
            {
                return this.cache.Get(request);
            }

            
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorizationResponse> GetAuthorizations(Guid subject, TimeSpan? span = null)
        {
            throw new NotImplementedException();
        }
    }
}
