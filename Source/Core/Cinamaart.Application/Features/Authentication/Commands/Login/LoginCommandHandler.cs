using AutoMapper;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.DTO;
using Cinamaart.Application.Features.Authentication.Queries;
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


namespace Cinamaart.Application.Features.Authentication.Commands.Login
{
    public class LoginCommandHandler(
        IMapper mapper,
        UserManager<User> userManager,
        ILogger<LoginCommandHandler> logger,
        IStringLocalizer<StringResources> localizer,
        [FromKeyedServices("JWT")] ITokenService tokenGenerator,
        IUserDeviceService userDeviceService
        )
        : IRequestHandler<LoginCommand, Result<AuthenticationResultDTO>>
    {
        private const int TOKEN_EXPIRATION_MINUTES = 120;
        public async Task<Result<AuthenticationResultDTO>> Handle(LoginCommand request, CancellationToken cancellationToken)
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

                if (user is null)
                {
                    return Result<AuthenticationResultDTO>.Failure("User.NotFound", localizer[LocalStringKeyword.User_NotFound]);
                }
                else
                {
                    bool passwordIsValid = await userManager.CheckPasswordAsync(user, request.Password);
                    if (passwordIsValid)
                    {
                        var deviceInfo = mapper.Map<LoginCommand, DeviceInfoDTO>(request);
                        var accessToken = await tokenGenerator.GenerateTokenAsync(user);
                        var refreshToken = await tokenGenerator.GenerateRefreshTokenAsync(user.Id, request.DeviceId);
                        await userDeviceService.SaveDeviceInfoAsync(user.Id, deviceInfo);

                        return Result<AuthenticationResultDTO>.Success(
                            new AuthenticationResultDTO(
                                accessToken.Token,
                                accessToken.Expiration,
                                refreshToken.Token,
                                refreshToken.Expiration));
                    }
                    else
                    {
                        return Result<AuthenticationResultDTO>.Failure("Login.Failed", localizer[LocalStringKeyword.Login_PasswordInCorrect]);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while Logging-in , requested data = {request}", request.ToJson());
                return Result<AuthenticationResultDTO>.Failure("Login.Exception", ex.Message);
            }
        }
    }
}
