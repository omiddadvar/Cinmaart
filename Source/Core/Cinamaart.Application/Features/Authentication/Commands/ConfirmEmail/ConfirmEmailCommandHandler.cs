using Cinamaart.Application.Features.Authentication.Commands.Login;
using Cinamaart.Application.Features.Authentication.Queries;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authentication.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler(
        ILogger<LoginCommandHandler> logger,
        IStringLocalizer<StringResources> localizer,
        UserManager<User> userManager
        )
        : IRequestHandler<ConfirmEmailCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return Result<bool>.Failure("User.NotFound", localizer[LocalStringKeyword.User_NotFound]);
                }
                var result = await userManager.ConfirmEmailAsync(user, request.Token);
                if (result.Succeeded)
                {
                    return Result<bool>.Success(true);
                }
                return result.ToStandardResult<bool>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while Confirming Email, requested data = {request}", request.ToJson());
                return Result<bool>.Failure("ConfirmEmail.Exception", ex.Message);
            }
        }
    }
}
