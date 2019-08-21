using System.Threading.Tasks;
using core;
using Refit;

namespace auth
{
    public interface IAuthenticatorService
    {
        [Post("")]
        Task<AuthenticatorResponse> Authenticate(AuthenticatorRequest request);
    }
}
