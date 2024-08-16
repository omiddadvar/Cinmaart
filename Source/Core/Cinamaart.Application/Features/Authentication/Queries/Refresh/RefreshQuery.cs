using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cinamaart.Application.Features.Authentication.Queries.Refresh
{
    public record RefreshQuery(
        string ExpiredAccessToken,
        string RefreshToken,
        string DeviceId
        ) : IRequest<Result<AuthenticationResultDTO>>;
}
