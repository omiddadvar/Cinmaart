using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Users.Commands.Lockout
{
    internal class LockoutCommandHandler(
            UserManager<User> userManager,
            IStringLocalizer<StringResources> localizer,
            ILogger<LockoutCommandHandler> logger
        ) : IRequestHandler<LockoutCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(LockoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId.ToString());
                if (user is not null)
                {
                    var identityResult = await userManager.SetLockoutEnabledAsync(user, request.Enabled);
                    return identityResult.ToStandardResult<bool>();
                }
                else
                    return Result<bool>.Failure("Lockout.NotFound",
                        localizer[LocalStringKeyword.User_NotFoundById, request.UserId]);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing user, userId = {userId}", request.UserId);
                return Result<bool>.Failure("Lockout.Exception", ex.Message);
            }
        }
    }
}
