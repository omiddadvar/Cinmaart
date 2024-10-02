using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Users.Commands.Lockout
{
    public record LockoutCommand(long UserId, bool Enabled) : IRequest<Result<bool>>;
}
