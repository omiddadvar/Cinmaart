using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Files.Commands.RemoveSubtitleFile
{
    public record RemoveSubtitleFileCommand(
            long SubtitleId
        ) : IRequest<WebServiceResult<bool>>;
}
