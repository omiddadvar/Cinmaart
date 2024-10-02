using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<Result<IList<UserDTO>>>;
}
