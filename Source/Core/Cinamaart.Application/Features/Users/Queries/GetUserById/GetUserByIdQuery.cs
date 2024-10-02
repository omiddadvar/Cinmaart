using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(long UserId) : IRequest<Result<UserDTO>>;
}
