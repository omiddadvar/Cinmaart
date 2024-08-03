using Cinamaart.Application.Abstractions.Settings;
using Cinamaart.Infrastructure.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Infrastructure.Configurations
{
    public class JwtSettting(IConfiguration configuration) : IJwtSettting
    {
        public string Issuer => configuration["JWT:Issuer"] ?? "Cinamaart Server";

        public string Audience => configuration["JWT:Audience"] ?? "Cinamaart Client";

        public SymmetricSecurityKey SecretKey => CustomSecurityKeyBasic.SymmetricSecurityKey;

        public int Expiration => Convert.ToInt32(configuration["JWT:Expire"] ?? "120");
    }
}
