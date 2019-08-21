using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;
using core;
using Microsoft.AspNetCore.Mvc;

namespace auth
{
    public class AuthActionFilter : IActionFilter
    {
        private const string SubjectClaim = "sub";

        private readonly IAuthenticatorService _authService;
        private readonly ServiceAuthOptions _options;

        public AuthActionFilter(IAuthenticatorService authService, ServiceAuthOptions options)
        {
            _authService = authService;
            _options = options;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var authAttribute = context
                .ActionDescriptor
                .FilterDescriptors
                .Select(x => x.Filter)
                .OfType<AuthAttribute>()
                .FirstOrDefault();

            if (authAttribute == null) return;

            var task = _authService.Authenticate(new AuthenticatorRequest()
            {
                Path = authAttribute.Path,
                Service = _options,
                Subject = GetSubject(context.HttpContext.User)
            });

            task.Wait();

            var result = task.Result;
                
            if (!result.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (result.IsAuthenticated && !result.IsAuthorized)
            {
                context.Result = new StatusCodeResult(403);
                return;
            }

            UpdateClaims(result, context);
        }

        private string GetSubject(ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal), "No User Found");

            var claim = principal.Claims.FirstOrDefault(c => c.Type == SubjectClaim);

            return claim?.Value;
        }

        private void UpdateClaims(AuthenticatorResponse response, ActionExecutingContext context)
        {
            var identity = (ClaimsIdentity) context.HttpContext.User.Identity;
            foreach (var a in response.Authorizations ?? new List<AuthorizeResult>())
            {
                var claimName = $"auth.{a.Object}";
                var existing = identity.Claims.FirstOrDefault(c => c.Type == claimName);

                if (existing != null)
                {
                    identity.RemoveClaim(existing);
                }

                identity.AddClaim(new Claim(claimName, a.Level));
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { /* noop */ }
    }
}
