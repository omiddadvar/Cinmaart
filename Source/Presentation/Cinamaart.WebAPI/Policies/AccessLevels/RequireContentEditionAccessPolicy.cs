using Cinamaart.Application.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Cinamaart.WebAPI.Policies.AccessLevels
{
    public static class RequireContentEditionAccessPolicy
    {
        public static void AddRequireContentEditionAccessPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(PolicyNames.RequireContentEditionAccess,
                policy =>
                {
                    policy.RequireRole(RoleNames.Administrator);
                    policy.RequireRole(RoleNames.ContentWriter);
                    policy.RequireRole(RoleNames.Support);
                });
        }
    }
}
