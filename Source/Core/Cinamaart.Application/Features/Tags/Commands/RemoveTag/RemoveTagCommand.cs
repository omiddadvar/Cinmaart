using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Tags.Commands.RemoveTag
{
    public record RemoveTagCommand(int Id) : IRequest<Result<bool>>;
}
