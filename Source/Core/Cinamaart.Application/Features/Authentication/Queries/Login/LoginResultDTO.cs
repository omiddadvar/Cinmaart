using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authentication.Queries.Login
{
    public record LoginResultDTO(string Token , int ExpirationMinutes);
}
