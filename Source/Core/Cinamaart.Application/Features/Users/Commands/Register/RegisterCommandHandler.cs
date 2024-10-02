using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Notification;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Features.Artists.Commands.AddArtist;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Users.Commands.Register
{
    public class RegisterCommandHandler (
            IMapper mapper,
            UserManager<User> userManager,
            ILogger<RegisterCommandHandler> logger,
            IEmailService emailService,
            IUrlService urlService,
            IStringLocalizer<StringResources> stringLocalizer
        ) : IRequestHandler<RegisterCommand, WebServiceResult<long?>>
    {
        public async Task<WebServiceResult<long?>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = mapper.Map<User>(request);
                var identityResult = await userManager.CreateAsync(user , request.Password);

                if (identityResult.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = urlService.GenerateEmailConfirmationUri(user.Id.ToString(), token);

                    await emailService.SendEmailAsync(
                            user.Email ?? string.Empty,
                            stringLocalizer[LocalStringKeyword.Email_UserRegistrationSubject],
                            stringLocalizer[LocalStringKeyword.Email_UserRegistrationSubject , confirmationLink]
                        );
                    return WebServiceResult<long?>.Success(user.Id);
                }
                else
                    return WebServiceResult<long?>.Failure(identityResult.Errors.ToErrors());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while registering user, requested data = {request}", request.ToJson());
                return WebServiceResult<long?>.Failure("Register.Exception", ex.Message);
            }
        }
    }
}
