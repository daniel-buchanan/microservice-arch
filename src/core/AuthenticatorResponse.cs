using System.Collections.Generic;

namespace core
{
    public class AuthenticatorResponse
    {
        public AuthenticatorRequest Request { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAuthorized { get; set; }
        public IEnumerable<AuthorizeResult> Authorizations { get; set; }
    }
}
