using Cinamaart.Domain.Entities.Pivots;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserDocument?> GetProfileUserDocument(long userId ,CancellationToken cancellationToken);
        Task<bool> RemoveUserProfile(UserDocument userDocument, CancellationToken cancellationToken);
        Task<UserDocument?> AddNewUserProfile(long userId , IFormFile formFile, CancellationToken cancellationToken);
    }
}
