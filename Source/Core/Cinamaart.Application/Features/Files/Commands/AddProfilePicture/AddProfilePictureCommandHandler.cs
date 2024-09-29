using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Extentions.Files;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Identity;
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

namespace Cinamaart.Application.Features.Files.Commands.AddProfilePicture
{
    internal class AddProfilePictureCommandHandler(
            IFileService fileService,
            UserManager<User> userManager,
            IStringLocalizer<StringResources> localizer,
            ILogger<AddProfilePictureCommandHandler> logger
        ) : IRequestHandler<AddProfilePictureCommand,Result<string>>
    {
        public async Task<Result<string>> Handle(AddProfilePictureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.File == null || request.File.Length == 0)
                {
                    return Result<string>.Failure(localizer[LocalStringKeyword.File_UploadNotFound]);
                }
                
                var isUploaded = await fileService.UploadFileAsync(request.File , request.File.GetDocType());
                return filePath;
            }
            catch(Exception ex)
            {
                logger.LogError("Error while updating profile picture for user : {userId}" , request.UserId);
                return Result<string>.Failure(ex.Message);
            }
        }
    }
}
