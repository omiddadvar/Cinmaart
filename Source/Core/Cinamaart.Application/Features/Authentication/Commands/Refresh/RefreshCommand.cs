using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Features.Authentication.Queries;
using MediatR;

namespace Cinamaart.Application.Features.Authentication.Commands.Refresh
{
    public record RefreshCommand(
        string ExpiredAccessToken,
        string RefreshToken,
        string DeviceId
        ) : IRequest<WebServiceResult<AuthenticationResultDTO>>;
}
