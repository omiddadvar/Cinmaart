using Cinamaart.WebAPI.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Cinamaart.WebAPI.Policies.AccessLevels
{
    public static class RequireSubtitleEditionAccessPolicy
    {
        public static void AddRequireSubtitleEditionAccessPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(PolicyNames.RequireSubtitleEditionAccess,
                policy => {
                    policy.RequireRole(RoleNames.Administrator);
                    policy.RequireRole(RoleNames.ContentWriter);
                    policy.RequireRole(RoleNames.Author);
                });
        }
    }
}
