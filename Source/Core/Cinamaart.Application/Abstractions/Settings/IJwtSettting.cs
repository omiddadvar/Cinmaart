using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions.Settings
{
    public interface IJwtSettting
    {
        public string Issuer { get; }
        public string Audience { get; }
        public SymmetricSecurityKey SecretKey { get; }
        /// <summary>
        /// Token Expiration In Minutes
        /// </summary>
        public int Expiration { get; }
    }
}
