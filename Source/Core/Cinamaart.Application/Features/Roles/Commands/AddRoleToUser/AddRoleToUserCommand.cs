using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Roles.Commands.AddRoleToUser
{
    public record AddRoleToUserCommand(long UserId, IList<string> Roles)
        : IRequest<Result<bool>>;
}
