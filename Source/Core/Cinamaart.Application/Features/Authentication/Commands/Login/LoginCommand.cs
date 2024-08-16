using Cinamaart.Application.Features.Authentication.Queries;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authentication.Commands.Login
{
    public record LoginCommand(
        string? Email,
        string? UserName,
        string Password,
        string DeviceId,
        string DeviceName,
        string OSVersion
        ) : IRequest<Result<AuthenticationResultDTO>>;
}
