using Cinamaart.Application.Abstractions.Settings;
using Cinamaart.Infrastructure.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cinamaart.Infrastructure.Configurations
{
    public class JwtSettting(IConfiguration configuration) : IJwtSettting
    {
        public string Issuer => configuration["JWT:Issuer"] ?? "Cinamaart Server";

        public string Audience => configuration["JWT:Audience"] ?? "Cinamaart Client";

        public SymmetricSecurityKey SecretKey => CustomSecurityKeyBasic.SymmetricSecurityKey;

        public TimeSpan AccessTokenExpiration => TimeSpan.FromMinutes(Convert.ToInt32(configuration["JWT:AccessTokenExpireMin"] ?? "120"));

        public TimeSpan RefreshTokenExpiration => TimeSpan.FromDays(Convert.ToInt32(configuration["JWT:RefreshTokenExpireDay"] ?? "7"));
    }
}
