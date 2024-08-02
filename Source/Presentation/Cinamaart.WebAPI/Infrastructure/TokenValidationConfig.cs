using Cinamaart.Application.Common.Security;
using Microsoft.IdentityModel.Tokens;

namespace Cinamaart.WebAPI.Infrastructure
{
    public class TokenValidationConfig
    {
        internal static TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                IssuerSigningKey = CustomSecurityKeyBasic.SymmetricSecurityKey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = "Cinamaart Server",
                ValidAudience = "Cinamaart Client",
                ValidateAudience = true,
                LifetimeValidator = CustomLifetimeValidator
            };
        }
        private static bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires,
                                    SecurityToken tokenToValidate, TokenValidationParameters @param)
        {
            if (expires != null)
            {
                return expires > DateTime.UtcNow;
            }
            return false;
        }
    }
}
