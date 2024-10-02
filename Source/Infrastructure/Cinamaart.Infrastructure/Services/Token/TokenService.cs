using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Abstractions.Settings;
using Cinamaart.Application.DTO;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Cinamaart.Infrastructure.Services.Token
{
    public class TokenService(
        IJwtSettting jwtSettting,
        IConnectionMultiplexer redis,
        UserManager<User> userManager,
        IStringLocalizer<StringResources> stringLocalizer,
        IConfiguration configuration) : ITokenService
    {
        public async Task<TokenResultDTO> GenerateTokenAsync(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var role in await userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return await GenerateTokenAsync(user, claims);
        }
        public async Task<TokenResultDTO> GenerateTokenAsync(User user, IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(jwtSettting.AccessTokenExpiration),
                SigningCredentials = new SigningCredentials(jwtSettting.SecretKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettting.Issuer,
                Audience = jwtSettting.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string accessToken = tokenHandler.WriteToken(token);
            return new TokenResultDTO(accessToken, DateTime.UtcNow.Add(jwtSettting.AccessTokenExpiration));
        }
        public async Task<TokenResultDTO> GenerateRefreshTokenAsync(long userId, string deviceId)
        {
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            var db = redis.GetDatabase();
            var key = $"{userId}:{deviceId}";
            await db.StringSetAsync(key, refreshToken, jwtSettting.RefreshTokenExpiration);
            return new TokenResultDTO(refreshToken, DateTime.UtcNow.Add(jwtSettting.RefreshTokenExpiration));
        }
        public async Task<bool> ValidateRefreshTokenAsync(long userId, string deviceId, string refreshToken)
        {
            var db = redis.GetDatabase();
            var key = $"{userId}:{deviceId}";
            var storedToken = await db.StringGetAsync(key);
            return storedToken == refreshToken;
        }
        public async Task RevokeRefreshTokenAsync(long userId, string deviceId)
        {
            var db = redis.GetDatabase();
            var key = $"{userId}:{deviceId}";
            await db.KeyDeleteAsync(key);
        }
        public async Task RevokeAllRefreshTokensAsync(string userId)
        {
            var server = redis.GetServer(redis.GetEndPoints().First());
            var db = redis.GetDatabase();
            var keys = server.Keys(pattern: $"{userId}:*").ToArray();

            foreach (var key in keys)
            {
                await db.KeyDeleteAsync(key);
            }
        }
        public async Task<long> GetUserIdFromExpiredTokenAsync(string expiredAccessToken)
        {

            var principal = GetPrincipalFromExpiredToken(expiredAccessToken);
            if (principal is null)
            {
                throw new SecurityTokenException(stringLocalizer[LocalStringKeyword.Auth_InvalidExpiredToken]);
            }
            long userId = Convert.ToInt64(principal.FindFirstValue(JwtRegisteredClaimNames.Sid));
            //string Username = principal.Identity.Name;
            return userId;
        }

        // Example method to get principal from expired token
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = jwtSettting.SecretKey,
                ValidateLifetime = false // Ignore token expiration
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
