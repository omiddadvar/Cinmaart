using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Commands.AddArtist;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
            ILogger<RegisterCommandHandler> logger
        ) : IRequestHandler<RegisterCommand, Result<long?>>
    {
        public async Task<Result<long?>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = mapper.Map<User>(request);
                var identityResult = await userManager.CreateAsync(user , request.Password);

                if (identityResult.Succeeded)
                    return Result<long?>.Success(user.Id);
                else
                    return Result<long?>.Failure("Register.Failure", identityResult.Errors.ToString());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while registering user, requested data = {request}", request.ToJson());
                return Result<long?>.Failure("Register.Exception", ex.Message);
            }
        }
    }
}
