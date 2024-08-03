using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Settings;
using Cinamaart.Infrastructure.Configurations;
using Cinamaart.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddKeyedTransient<ITokenGenerator, JWTBearerTokenGenerator>("JWT");

            services.AddSingleton<IJwtSettting, JwtSettting>();

            return services;
        }
    }
}
