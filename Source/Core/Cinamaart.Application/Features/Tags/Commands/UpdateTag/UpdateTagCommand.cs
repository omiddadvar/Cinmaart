using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Tags.Commands.UpdateTag
{
    public record UpdateTagCommand(
            int Id,
            string Name
        ) : IRequest<Result<TagDTO>>;
}
