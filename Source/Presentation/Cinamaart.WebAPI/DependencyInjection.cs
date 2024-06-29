using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Persistence.Contexts;
using Cinamaart.WebAPI.Policies;
using Cinamaart.WebAPI.Policies.AccessLevels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cinamaart.WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services)
        {

            services.AddOutputCache(options =>
            {
                options.AddBasePolicy(builder => builder.Cache());
                options.AddPolicy("OutputCacheWithAuthPolicy", OutputCacheWithAuthPolicy.Instance);
                options.UseCaseSensitivePaths = false;
                options.DefaultExpirationTimeSpan = TimeSpan.FromDays(1);
            });

            services.AddAuthorization(options =>
            {
                options.AddRequireContentEditionAccessPolicy();
                options.AddRequireSubtitleEditionAccessPolicy();
            });
            services.AddAuthentication();

            services.AddIdentityCore<User>(options =>
            {
                // Password settings.
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            })
                //.AddRoles<Role>()
                .AddEntityFrameworkStores<MainDBContext>()
                .AddDefaultTokenProviders()
                .AddApiEndpoints();

            return services;
        }
    }
}
