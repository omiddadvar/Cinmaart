using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Common.Security;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;


namespace Cinamaart.Application.Features.Authentication.Queries.Login
{
    public class LoginCommandHandler(
        UserManager<User> userManager,
        ILogger<LoginCommandHandler> logger,
        IStringLocalizer<StringResources> localizer,
        [FromKeyedServices("JWT")] ITokenGenerator tokenGenerator
        )
        : IRequestHandler<LoginCommand, Result<LoginResultDTO>>
    {
        private const int TOKEN_EXPIRATION_MINUTES = 120;
        public async Task<Result<LoginResultDTO>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User? user = null;
                if (!string.IsNullOrWhiteSpace(request.Email))
                {
                    user = await userManager.FindByEmailAsync(request.Email);
                }
                else if (!string.IsNullOrWhiteSpace(request.UserName))
                {
                    user = await userManager.FindByNameAsync(request.UserName);
                }

                if(user is null)
                {
                    return Result<LoginResultDTO>.Failure("User.NotFound" , localizer[LocalStringKeyword.User_NotFound]);
                }
                else
                {
                    bool passwordIsValid = await userManager.CheckPasswordAsync(user, request.Password);
                    if (passwordIsValid)
                    {
                        string token = await tokenGenerator.GenerateJwtTokenAsync(user);

                        return Result<LoginResultDTO>.Success(
                            new LoginResultDTO(token, TOKEN_EXPIRATION_MINUTES));
                    }
                    else
                    {
                        return Result<LoginResultDTO>.Failure("Login.Failed", localizer[LocalStringKeyword.Login_PasswordInCorrect]);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while Logging-in , requested data = {request}", request.ToJson());
                return Result<LoginResultDTO>.Failure("Login.Exception", ex.Message);
            }
        }
    }
}
