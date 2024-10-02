using AutoMapper;
using Cinamaart.Application.Abstractions.Notification;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Users.Commands.Register
{
    public class RegisterCommandHandler(
            IMapper mapper,
            UserManager<User> userManager,
            ILogger<RegisterCommandHandler> logger,
            IEmailService emailService,
            IUrlService urlService,
            IStringLocalizer<StringResources> stringLocalizer
        ) : IRequestHandler<RegisterCommand, Result<long?>>
    {
        public async Task<Result<long?>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = mapper.Map<User>(request);
                var identityResult = await userManager.CreateAsync(user, request.Password);

                if (identityResult.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = urlService.GenerateEmailConfirmationUri(user.Id.ToString(), token);

                    await emailService.SendEmailAsync(
                            user.Email ?? string.Empty,
                            stringLocalizer[LocalStringKeyword.Email_UserRegistrationSubject],
                            stringLocalizer[LocalStringKeyword.Email_UserRegistrationSubject, confirmationLink]
                        );
                    return Result<long?>.Success(user.Id);
                }
                else
                    return Result<long?>.Failure(identityResult.Errors.ToErrors());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while registering user, requested data = {request}", request.ToJson());
                return Result<long?>.Failure("Register.Exception", ex.Message);
            }
        }
    }
}
