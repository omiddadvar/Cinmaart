using Cinamaart.Application.Features.Users.Commands.Register;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Users.Commands.RemoveUser
{
    public class RemoveUserCommandHandler(
            UserManager<User> userManager,
            ILogger<RegisterCommandHandler> logger,
            IStringLocalizer<StringResources> localizer
        ) : IRequestHandler<RemoveUserCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId.ToString());
                if (user is not null)
                {
                    var identityResult = await userManager.DeleteAsync(user);
                    return identityResult.ToStandardResult<bool>();
                }
                else
                    return Result<bool>.Failure("RemoveUser.NotFound",
                        localizer[LocalStringKeyword.User_NotFoundById, request.UserId]);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing user, userId = {userId}", request.UserId);
                return Result<bool>.Failure("RemoveUser.Exception", ex.Message);
            }
        }
    }
}
