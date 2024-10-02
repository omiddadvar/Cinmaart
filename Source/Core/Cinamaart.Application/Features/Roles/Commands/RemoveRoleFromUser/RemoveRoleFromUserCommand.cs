using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Roles.Commands.RemoveRoleFromUser
{
    public record RemoveRoleFromUserCommand(long UserId, IList<string> Roles)
    : IRequest<Result<bool>>;
}
