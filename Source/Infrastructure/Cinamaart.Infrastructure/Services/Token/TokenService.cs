using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Settings;
using Cinamaart.Application.DTO;
using Cinamaart.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Infrastructure.Services.Token
{
    public class TokenService(
        IJwtSettting jwtSettting,
        IConnectionMultiplexer redis, 
        IConfiguration configuration) : ITokenService
    {
        public async Task<TokenResultDTO> GenerateTokenAsync(User user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            return await GenerateTokenAsync(user, claims);
        }
        public async Task<TokenResultDTO> GenerateTokenAsync(User user, Claim[] claims)
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
    }
}
