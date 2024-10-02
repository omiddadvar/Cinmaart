using Cinamaart.Application.Abstractions.Notification;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Abstractions.Settings;
using Cinamaart.Infrastructure.Configurations;
using Cinamaart.Infrastructure.Services;
using Cinamaart.Infrastructure.Services.Notification;
using Cinamaart.Infrastructure.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;


namespace Cinamaart.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var configuration = serviceProvider.GetService<IConfiguration>();
            // Redis Service
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")));
            // Authentication Services
            services.AddKeyedTransient<ITokenService, TokenService>("JWT");
            services.AddSingleton<IJwtSettting, JwtSettting>();
            // Notification Services
            services.AddTransient<IEmailService, EmailService>();
            //Utility Services
            services.AddTransient<IUrlService, UrlService>();
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
