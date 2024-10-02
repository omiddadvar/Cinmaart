using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Tags.Queries.GetAllTags
{
    public record GetAllTagsQuery : IRequest<WebServiceResult<IList<TagDTO>>>;
}
