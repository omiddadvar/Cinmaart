using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authentication.Queries
{
    public record AuthenticationResultDTO(
        string Token,
        DateTime TokenExpiresAt,
        string RefreshToken,
        DateTime RefreshTokenExpiresAt
        );
}
