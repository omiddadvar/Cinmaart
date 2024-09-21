using AutoMapper;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Extentions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Users.Queries.GetAllUsers
{
    internal class GetAllUsersQueryHandler(
            IMapper mapper,
            UserManager<User> userManager,
            IStringLocalizer<StringResources> localizer,
            ILogger<GetAllUsersQueryHandler> logger
        ) : IRequestHandler<GetAllUsersQuery, Result<IList<UserDTO>>{
        public async Task<Result<IList<UserDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await userManager.Users.ToArrayAsync();
                if (users.IsNullOrEmpty())
                    return Result<IList<UserDTO>>.Failure("GetAllUsers.NotFound",
                        localizer[LocalStringKeyword.User_NotFound]);
                else
                {
                    var userData = mapper.Map<UserDTO[]>(users);
                    return Result<IList<UserDTO>>.Success(userData);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while fetching all users data");
                return Result<IList<UserDTO>>.Failure("GetAllUsers.Exception", ex.Message);
            }
        }
    }
}
