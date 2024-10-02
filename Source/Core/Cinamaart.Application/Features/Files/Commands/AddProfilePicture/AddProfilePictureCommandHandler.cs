using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Extentions.Files;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Files.Commands.AddProfilePicture
{
    internal class AddProfilePictureCommandHandler(
            IFileService fileService,
            UserManager<User> userManager,
            IStringLocalizer<StringResources> localizer,
            ILogger<AddProfilePictureCommandHandler> logger
        ) : IRequestHandler<AddProfilePictureCommand, WebServiceResult<string>>
    {
        public async Task<WebServiceResult<string>> Handle(AddProfilePictureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.File == null || request.File.Length == 0)
                {
                    return WebServiceResult<string>.Failure(localizer[LocalStringKeyword.File_UploadNotFound]);
                }

                var isUploaded = await fileService.UploadFileAsync(request.File, request.File.GetDocType());
                return filePath;
            }
            catch (Exception ex)
            {
                logger.LogError("Error while updating profile picture for user : {userId}", request.UserId);
                return WebServiceResult<string>.Failure(ex.Message);
            }
        }
    }
}
