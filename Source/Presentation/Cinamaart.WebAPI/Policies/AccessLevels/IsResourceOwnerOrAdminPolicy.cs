using Cinamaart.Application.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Cinamaart.WebAPI.Policies.AccessLevels
{
    public static class IsResourceOwnerOrAdminPolicy
    {
        public static void AddIsResourceOwnerOrAdminPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(PolicyNames.IsResourceOwnerOrAdmin, policy =>
                  policy.RequireAssertion(context =>
                  {
                      var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                      var isAdmin = context.User.IsInRole(RoleNames.Administrator);

                      if (userIdClaim == null && !isAdmin) return false;

                      // Assume that the route parameter is called 'userId'
                      var httpContext = context.Resource as HttpContext;
                      var requestUserId = httpContext?.Request.RouteValues["userId"]?.ToString();

                      // Grant access if the user is accessing their own data or is an admin
                      return userIdClaim == requestUserId || isAdmin;
                  }));
        }

    }
}
