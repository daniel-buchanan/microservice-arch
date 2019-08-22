using System.Threading.Tasks;
using core;

namespace api.authenticator.Services 
{
    public interface IAuthenticatorService 
    {
        Task<AuthenticatorResponse> Authenticate(AuthenticatorRequest request);
    }
}