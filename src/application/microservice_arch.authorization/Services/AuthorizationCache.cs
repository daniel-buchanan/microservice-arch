using System;
using System.Collections.Generic;
using microservice_arch.common.auth;

namespace microservice_arch.authorization.Services
{
    public interface IAuthorizationCache
    {
        bool IsAuthorized(AuthorizationRequest request);
        bool IsAuthorized(string hash);
        bool Exists(AuthorizationRequest request);
        bool Exists(string hash);
        bool IsExpired(AuthorizationRequest request);
        bool IsExpired(string hash);
        void Add(AuthorizationRequest request, AuthorizationResponse response);
        void Clear();
        AuthorizationResponse Get(AuthorizationRequest request);
        AuthorizationResponse Get(string hash);
    }

    public class AuthorizationCache : IAuthorizationCache
    {
        private readonly Dictionary<AuthorizationRequest, string> reverseMapping; 
        private readonly Dictionary<string, AuthorizationResponse> cache;

        public AuthorizationCache()
        {
            this.cache = new Dictionary<string, AuthorizationResponse>();
            this.reverseMapping = new Dictionary<AuthorizationRequest, string>();
        }

        private string GetHash(AuthorizationRequest request)
        {
            if (request == null) return null;

            if (this.reverseMapping.ContainsKey(request))
                return this.reverseMapping[request];

            var hash = request.GetHash();
            this.reverseMapping.Add(request, hash);
            return hash;
        }

        public bool IsAuthorized(AuthorizationRequest request) => IsAuthorized(GetHash(request));

        public bool IsAuthorized(string hash)
        {
            if (!Exists(hash)) return false;
            if (IsExpired(hash)) return false;

            var response = this.cache[hash];
            return response.Success;
        }

        public bool Exists(AuthorizationRequest request) => Exists(GetHash(request));

        public bool Exists(string hash) => this.cache.ContainsKey(hash);

        public bool IsExpired(AuthorizationRequest request) => IsExpired(GetHash(request));

        public bool IsExpired(string hash)
        {
            if (!Exists(hash)) return true;
            var response = this.cache[hash];

            if (response.Expires == null) return false;

            return response.Expires < DateTimeOffset.Now;
        }

        public void Add(AuthorizationRequest request, AuthorizationResponse response)
        {
            if(request == null) throw new ArgumentNullException(nameof(request), "Request cannot be NULL.");

            var hash = request?.GetHash();

            if (Exists(hash)) this.cache[hash] = response;
            else this.cache.Add(hash, response);
        }

        public void Clear() => this.cache.Clear();

        public AuthorizationResponse Get(AuthorizationRequest request) => Get(GetHash(request));

        public AuthorizationResponse Get(string hash)
        {
            if (!Exists(hash)) return null;
            return this.cache[hash];
        }
    }
}
