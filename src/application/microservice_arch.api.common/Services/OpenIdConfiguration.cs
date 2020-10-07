using System.Collections.Generic;
using Newtonsoft.Json;

namespace microservice_arch.api.common.Services
{
    public class OpenIdConfiguration
    {
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("authorization_endpoint")]
        public string AuthorizationEndpoint { get; set; }

        [JsonProperty("token_endpoint")]
        public string TokenEndpoint { get; set; }

        [JsonProperty("introspection_endpoint")]
        public string IntrospectionEndpoint { get; set; }

        [JsonProperty("userinfo_endpoint")]
        public string UserInfoEndpoint { get; set; }

        [JsonProperty("end_session_endpoint")]
        public string EndSessionEndpoint { get; set; }

        [JsonProperty("jwks_uri")]
        public string JWKSUri { get; set; }

        [JsonProperty("check_session_iframe")]
        public string CheckSessionIFrame { get; set; }

        [JsonProperty("grant_types_supported")]
        public List<string> SupportedGrantTypes { get; set; }

        [JsonProperty("response_types_supported")]
        public List<string> SupportedResponseTypes { get; set; }

        [JsonProperty("subject_types_supported")]
        public List<string> SupportedSubjectTypes { get; set; }

        [JsonProperty("subject_types_supported")]
        public List<string> SupportedClaims { get; set; }
    }
}
