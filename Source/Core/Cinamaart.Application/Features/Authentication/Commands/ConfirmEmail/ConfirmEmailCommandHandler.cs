using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Extentions;
using Cinamaart.Application.Features.Authentication.Commands.Login;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Authentication.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler(
        ILogger<LoginCommandHandler> logger,
        IStringLocalizer<StringResources> localizer,
        UserManager<User> userManager
        )
        : IRequestHandler<ConfirmEmailCommand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return WebServiceResult<bool>.Failure("User.NotFound", localizer[LocalStringKeyword.User_NotFound]);
                }
                var result = await userManager.ConfirmEmailAsync(user, request.Token);
                if (result.Succeeded)
                {
                    return WebServiceResult<bool>.Success(true);
                }
                return result.ToStandardWebServiceResult<bool>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while Confirming Email, requested data = {request}", request.ToJson());
                return WebServiceResult<bool>.Failure("ConfirmEmail.Exception", ex.Message);
            }
        }
    }
}
