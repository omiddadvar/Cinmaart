﻿using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Persistence.Contexts;
using Cinamaart.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cinamaart.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<MainDBContext>(
              options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddRepositories();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IArtistRepository, ArtistRepository>();
            return services;
        }
    }
}
