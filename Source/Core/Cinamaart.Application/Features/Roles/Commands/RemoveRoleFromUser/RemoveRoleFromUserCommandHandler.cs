using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Extentions;
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
        ) : IRequestHandler<RemoveRoleFromUserCommand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.UserId));
                var result = await userManager.RemoveFromRolesAsync(user, request.Roles);
                return result.ToStandardWebServiceResult<bool>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing roles from user, data = {request}" , request.ToJson());
                return WebServiceResult<bool>.Failure("RemoveRoleFromUser.Exception", ex.Message);
            }
        }
    }
}
