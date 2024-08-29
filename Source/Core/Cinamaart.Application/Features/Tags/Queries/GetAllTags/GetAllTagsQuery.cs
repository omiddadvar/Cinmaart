using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Tags.Queries.GetAllTags
{
    public record GetAllTagsQuery : IRequest<Result<IList<TagDTO>>>;
}
