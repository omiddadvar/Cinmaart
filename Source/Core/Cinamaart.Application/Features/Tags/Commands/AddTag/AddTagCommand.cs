using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Tags.Commands.AddTag
{
    public record AddTagCommand(
        string Name
        ) : IRequest<Result<TagDTO>>;
}
