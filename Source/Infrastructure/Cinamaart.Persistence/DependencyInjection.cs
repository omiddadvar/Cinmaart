using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            string Conn = "Server=.;Database=Cinamaart;Trusted_Connection=True;TrustServerCertificate=True;Connection Timeout=3000;User ID=sa;Password=Essi@358;Integrated Security=False;Command timeout=3000";
            services.AddDbContext<MainDBContext>(
                options => options.UseSqlServer(Conn));
           // options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            return services;
        }
    }
}
