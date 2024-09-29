using Cinamaart.Application.Abstractions.Constants;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Cinamaart.WebAPI.Extentions
{
    public static class HTTPContextExtentions
    {
        public static bool IsSameUser(this HttpContext httpContext , long userId)
        {
            var contextUserId = httpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return contextUserId?.Equals(userId) ?? false;
        }
        public static bool IsSameUserOrAdmin(this HttpContext httpContext, long userId)
        {
            var contextUserId = httpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var isAdmin = _RoleExistsInClaims(httpContext.User.Claims , RoleNames.Administrator);

            return (contextUserId?.Equals(userId) ?? false) || isAdmin;
        }
        public static bool? UserHasRole(this HttpContext httpContext , string roleName)
        {
            if (httpContext.User is null) return null;
            if (httpContext.User.Claims is null) return null;

            return _RoleExistsInClaims(httpContext.User.Claims , roleName);
        }
        public static string[]? GetUserRoles(this HttpContext httpContext)
        {
            if (httpContext.User is null) return null;
            if (httpContext.User.Claims is null) return null;

            return _GetRolesFromClaims(httpContext.User.Claims);
        }
        private static bool _RoleExistsInClaims(IEnumerable<Claim> claims , string roleName)
        {
            return claims
                .Where(c => c.Type == ClaimTypes.Role && c.Value == roleName)
                .Any();
        }
        private static string[] _GetRolesFromClaims(IEnumerable<Claim> claims)
        {
            return claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToArray();
        }
    }
}
