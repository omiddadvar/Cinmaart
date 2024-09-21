using AutoMapper;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(
        IMapper mapper,
        UserManager<User> userManager,
        ILogger<GetUserByIdQueryHandler> logger,
        IStringLocalizer<StringResources> localizer
        ) :
        IRequestHandler<GetUserByIdQuery, Result<UserDTO>>
    {
        public async Task<Result<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await userManager.FindByIdAsync(request.UserId.ToString());

                if (user is not null)
                {
                    UserDTO userDTO = mapper.Map<UserDTO>(user);
                    return Result<UserDTO>.Success(userDTO);
                }
                else
                    return Result<UserDTO>.Failure("User.NotFound", localizer[LocalStringKeyword.User_NotFoundById, request.UserId]);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while retrieving user data by id, UserId = {id}", request.UserId);
                return Result<UserDTO>.Failure("GetUserById.Exception", ex.Message);
            }
        }
    }
}
