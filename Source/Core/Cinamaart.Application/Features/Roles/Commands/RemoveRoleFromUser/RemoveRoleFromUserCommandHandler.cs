using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Roles.Commands.RemoveRoleFromUser
{
    internal class RemoveRoleFromUserCommandHandler(
            UserManager<User> userManager,
            ILogger<RemoveRoleFromUserCommandHandler> logger
        ) : IRequestHandler<RemoveRoleFromUserCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.UserId));
                var result = await userManager.RemoveFromRolesAsync(user, request.Roles);
                return result.ToStandardResult<bool>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing roles from user, data = {request}" , request.ToJson());
                return Result<bool>.Failure("RemoveRoleFromUser.Exception", ex.Message);
            }
        }
    }
}
