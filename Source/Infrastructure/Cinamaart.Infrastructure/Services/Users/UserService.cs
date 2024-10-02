using Cinamaart.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Cinamaart.Infrastructure.Services.Users
{
    internal class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
    {
        public long? GetUserId()
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user is null)
                return null;

            return Convert.ToInt64(user.FindFirstValue(JwtRegisteredClaimNames.Sid));
        }

        public string? GetUserName()
        {
            var user = httpContextAccessor.HttpContext?.User;
            return user?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
