using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Features.Authentication.Commands.Login;
using Cinamaart.Application.Features.Authentication.Queries;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Authentication.Commands.Refresh
{
    public class RefreshCommandHandler(
            UserManager<User> userManager,
            ILogger<LoginCommandHandler> logger,
            IStringLocalizer<StringResources> localizer,
            [FromKeyedServices("JWT")] ITokenService tokenService
        ) : IRequestHandler<RefreshCommand, WebServiceResult<AuthenticationResultDTO>>
    {
        public async Task<WebServiceResult<AuthenticationResultDTO>> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            try
            {
                long userID = await tokenService.GetUserIdFromExpiredTokenAsync(request.ExpiredAccessToken);
                if (!await tokenService.ValidateRefreshTokenAsync(userID, request.DeviceId, request.RefreshToken))
                {
                    return WebServiceResult<AuthenticationResultDTO>.Failure("RefreshToken.NotValid", localizer[LocalStringKeyword.Auth_RefreshTokenNotMatch]);
                }
                else
                {
                    User? user = await userManager.FindByIdAsync(userID.ToString());
                    if (user is null)
                    {
                        return WebServiceResult<AuthenticationResultDTO>.Failure("User.NotFound", localizer[LocalStringKeyword.User_NotFound]);
                    }
                    else
                    {
                        var accessToken = await tokenService.GenerateTokenAsync(user);
                        var refreshToken = await tokenService.GenerateRefreshTokenAsync(user.Id, request.DeviceId);

                        return WebServiceResult<AuthenticationResultDTO>.Success(
                             new AuthenticationResultDTO(
                                 accessToken.Token,
                                 accessToken.Expiration,
                                 refreshToken.Token,
                                 refreshToken.Expiration));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while refreshing token , requested data = {request}", request.ToJson());
                return WebServiceResult<AuthenticationResultDTO>.Failure("RefreshToken.Exception", ex.Message);
            }
        }
    }
}
