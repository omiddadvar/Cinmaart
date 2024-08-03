using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Settings;
using Cinamaart.Domain.Entities.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Infrastructure.Services.Token
{
    public class JWTBearerTokenGenerator(IJwtSettting jwtSettting) : ITokenGenerator
    {
        public async Task<string> GenerateTokenAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(jwtSettting.Expiration),
                SigningCredentials = new SigningCredentials(jwtSettting.SecretKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettting.Issuer,
                Audience = jwtSettting.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
