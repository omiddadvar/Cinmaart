using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using Cinamaart.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
