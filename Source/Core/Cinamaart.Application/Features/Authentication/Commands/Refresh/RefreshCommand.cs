using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Features.Authentication.Queries;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cinamaart.Application.Features.Authentication.Commands.Refresh
{
    public record RefreshCommand(
        string ExpiredAccessToken,
        string RefreshToken,
        string DeviceId
        ) : IRequest<WebServiceResult<AuthenticationResultDTO>>;
}
