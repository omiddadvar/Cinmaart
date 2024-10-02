using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Users.Commands.RemoveUser
{
    public record RemoveUserCommand(long UserId) : IRequest<Result<bool>>;
}
