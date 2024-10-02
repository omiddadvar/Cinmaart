using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Roles.Queries.GetAllRoles
{
    public record GetAllRolesQuery() : IRequest<Result<IList<string>>>;
}
