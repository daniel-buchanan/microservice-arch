using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace microservice_arch.api.common.Services
{
    public class JwtBearerOptionsConfigurer : IConfigureOptions<JwtBearerOptions>
    {
        readonly IAuthLocatorService authLocatorService;

        public JwtBearerOptionsConfigurer(IAuthLocatorService authLocatorService)
        {
            this.authLocatorService = authLocatorService;
        }

        public async void Configure(JwtBearerOptions options)
        {
            var openIdConfig = await this.authLocatorService.GetOpenIdConfiguration();

            // Do the JWT validation
            options.SaveToken = true;
            options.Configuration = new OpenIdConnectConfiguration()
            {
                AuthorizationEndpoint = openIdConfig.AuthorizationEndpoint,
                CheckSessionIframe = openIdConfig.CheckSessionIFrame,
                JwksUri = openIdConfig.JWKSUri,
                Issuer = openIdConfig.Issuer,
                EndSessionEndpoint = openIdConfig.EndSessionEndpoint,
                TokenEndpoint = openIdConfig.TokenEndpoint,
                UserInfoEndpoint = openIdConfig.UserInfoEndpoint
            };
        }
    }
}
