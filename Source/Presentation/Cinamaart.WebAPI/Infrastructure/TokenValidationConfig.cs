using Cinamaart.Application.Abstractions.Settings;
using Microsoft.IdentityModel.Tokens;

namespace Cinamaart.WebAPI.Infrastructure
{
    public class TokenValidationConfig(IJwtSettting jwtSettting)
    {
        internal TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                IssuerSigningKey = jwtSettting.SecretKey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = jwtSettting.Issuer,
                ValidAudience = jwtSettting.Audience,
                ValidateAudience = true,
                LifetimeValidator = CustomLifetimeValidator
            };
        }
        private bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires,
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
