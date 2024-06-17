﻿using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Persistence.Contexts;
using Cinamaart.WebAPI.Policies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

            services.AddIdentity<User, Role>(options =>
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
                .AddEntityFrameworkStores<MainDBContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
