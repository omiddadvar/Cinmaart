using AutoMapper;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Roles.Queries.GetUserRoles
{
    internal class GetUserRolesQueryHandler(
        IMapper mapper,
        UserManager<User> userManager,
        IStringLocalizer<StringResources> localizer,
        ILogger<GetUserRolesQueryHandler> logger
        ) : IRequestHandler<GetUserRolesQuery, Result<IList<string>>>
    {
        public async Task<Result<IList<string>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.UserId is null)
                    return Result<IList<string>>.Failure("GetUserRoles.NotFound", localizer[LocalStringKeyword.User_NotFound]);

                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.UserId));

                if (user is null)
                    return Result<IList<string>>.Failure("GetUserRoles.NotFound", localizer[LocalStringKeyword.User_NotFound]);
                
                var roles = await userManager.GetRolesAsync(user);
                return Result<IList<string>>.Success(roles);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while fetching roles for user, userId = {userId}", request.UserId);
                return Result<IList<string>>.Failure("GetUserRoles.Exception", ex.Message);
            }
        }
    }
}
