using Cinamaart.Application.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Cinamaart.Application.Features.Files.Commands.AddProfilePicture
{
    public record AddProfilePictureCommand(
        IFormFile File,
        long UserId) : IRequest<WebServiceResult<bool>>;
}
