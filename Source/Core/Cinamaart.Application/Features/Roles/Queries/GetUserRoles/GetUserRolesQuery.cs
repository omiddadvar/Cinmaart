using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Roles.Queries.GetUserRoles
{
    public record GetUserRolesQuery(long? UserId) : IRequest<Result<IList<string>>>;
}
