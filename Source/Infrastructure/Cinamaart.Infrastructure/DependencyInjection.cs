using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Settings;
using Cinamaart.Infrastructure.Configurations;
using Cinamaart.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;


namespace Cinamaart.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            IConfiguration configuration;
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopedFactory.CreateScope())
            {
                configuration = scope.ServiceProvider.GetService<IConfiguration>();
            }

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")));
            
            services.AddKeyedTransient<ITokenService, TokenService>("JWT");

            services.AddSingleton<IJwtSettting, JwtSettting>();

            return services;
        }
    }
}
