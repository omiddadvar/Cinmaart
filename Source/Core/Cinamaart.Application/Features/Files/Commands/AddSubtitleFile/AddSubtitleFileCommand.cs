using Cinamaart.Application.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Cinamaart.Application.Features.Files.Commands.AddSubtitleFile
{

    public record AddSubtitleFileCommand(
        IFormFile File,
        long Subtitle) : IRequest<WebServiceResult<string>>;
}
