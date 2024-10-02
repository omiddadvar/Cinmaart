using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Authentication.Commands.ConfirmEmail
{
    public record ConfirmEmailCommand(
        long UserId,
        string Token
        ) : IRequest<WebServiceResult<bool>>;
}
