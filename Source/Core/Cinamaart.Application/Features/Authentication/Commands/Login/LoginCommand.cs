using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Features.Authentication.Queries;
using MediatR;

namespace Cinamaart.Application.Features.Authentication.Commands.Login
{
    public record LoginCommand(
        string? Email,
        string? UserName,
        string Password,
        string DeviceId,
        string DeviceName,
        string OSVersion
        ) : IRequest<WebServiceResult<AuthenticationResultDTO>>;
}
