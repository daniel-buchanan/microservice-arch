using System.Threading.Tasks;
using core;


namespace api.authenticator.Services 
{
    public class AuthenticatorService : IAuthenticatorService 
    {
        public Task<AuthenticatorResponse> Authenticate(AuthenticatorRequest request) 
        {
            return Task.FromResult(new AuthenticatorResponse());
        }
    }
}