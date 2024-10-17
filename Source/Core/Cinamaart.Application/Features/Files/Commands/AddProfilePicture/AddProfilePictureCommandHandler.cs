using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Extentions.Files;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Files.Commands.AddProfilePicture
{
    internal class AddProfilePictureCommandHandler(
            IFileService fileService,
            UserManager<User> userManager,
            IUserProfileRepository userProfileRepository,
            IStringLocalizer<StringResources> localizer,
            ILogger<AddProfilePictureCommandHandler> logger
        ) : IRequestHandler<AddProfilePictureCommand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(AddProfilePictureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.File == null || request.File.Length == 0)
                {
                    return WebServiceResult<bool>.NotFound(
                        localizer[LocalStringKeyword.File_UploadNotFound]);
                }
                var currentUserProfile = await userProfileRepository.GetProfileUserDocument(request.UserId, cancellationToken);
                if (currentUserProfile is not null)
                {
                    await userProfileRepository.RemoveUserProfile(currentUserProfile, cancellationToken);
                    await fileService.DeleteFileAsync(currentUserProfile.Document.SavedName);
                }
                var newUserProfile = await userProfileRepository.AddNewUserProfile(request.UserId, request.File, cancellationToken);
                
                var isUploaded = await fileService.UploadFileAsync(request.File , newUserProfile?.Document.SavedName);
                if (isUploaded)
                    return WebServiceResult<bool>.Success(true);
                else
                {
                    await userProfileRepository.RemoveUserProfile(newUserProfile, cancellationToken);
                    return WebServiceResult<bool>.Failure("AddProfilePicture.UploadFailed",
                        localizer[LocalStringKeyword.File_UploadFailure]);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error while updating profile picture for user : {userId}", request.UserId);
                return WebServiceResult<bool>.Failure("AddProfilePicture.Exception", ex.Message);
            }
        }
    }
}
