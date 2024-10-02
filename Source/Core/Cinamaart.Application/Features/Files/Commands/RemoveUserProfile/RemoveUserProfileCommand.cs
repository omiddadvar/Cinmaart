using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Files.Commands.RemoveUserProfile
{
    public record RemoveUserProfileCommand(
        long UserId
    ) : IRequest<WebServiceResult<bool>>;
}
