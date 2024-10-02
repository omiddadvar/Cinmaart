using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Roles.Queries.GetAllRoles
{
    internal class GetAllRolesQueryHandler(
            IMapper mapper,
            IRoleRepository roleRepository,
            ILogger<GetAllRolesQueryHandler> logger
        ) : IRequestHandler<GetAllRolesQuery, Result<IList<string>>>
    {
        public async Task<Result<IList<string>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = await roleRepository.GetAllAsync();
                var data = roles.Select(r => r.Name).ToArray();
                return Result<IList<string>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while fetching all roles");
                return Result<IList<string>>.Failure("GetAllRoles.Exception", ex.Message);
            }
        }
    }
}
