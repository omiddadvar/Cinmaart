using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Persistence.Contexts;
using Cinamaart.WebAPI.Policies;
using Cinamaart.WebAPI.Policies.AccessLevels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Globalization;

namespace Cinamaart.WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services)
        {

            services.AddOutputCacheDI();
            services.AddAuthDI();
            services.AddIdentityDI();
            services.AddLocalizationDI();
            return services;
        }
        private static IServiceCollection AddOutputCacheDI(this IServiceCollection services)
        {
            services.AddOutputCache(options =>
            {
                options.AddBasePolicy(builder => builder.Cache());
                options.AddPolicy("OutputCacheWithAuthPolicy", OutputCacheWithAuthPolicy.Instance);
                options.UseCaseSensitivePaths = false;
                options.DefaultExpirationTimeSpan = TimeSpan.FromDays(1);
            });
            return services;
        }
        private static IServiceCollection AddAuthDI(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddRequireContentEditionAccessPolicy();
                options.AddRequireSubtitleEditionAccessPolicy();
            });
            services.AddAuthentication();
            return services
        }
        private static IServiceCollection AddIdentityDI(this IServiceCollection services)
        {
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
        private static IServiceCollection AddLocalizationDI(this IServiceCollection services)
        {
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Cinamaart.SharedKernel.Resources";
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("fa-IR")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "fa-IR");
                options.SupportedCultures = supportedCultures;
                options.RequestCultureProviders = new[]
                {
                  new RouteDataRequestCultureProvider()
                };
            });
            return services;
        }
    }
}
