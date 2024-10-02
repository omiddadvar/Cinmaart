using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Tags.Queries.GetAllTags
{
    internal class GetAllTagsQueryHandler(
            IMapper mapper,
            ITagRepository tagRepository,
            ILogger<GetAllTagsQueryHandler> logger
        ) : IRequestHandler<GetAllTagsQuery, Result<IList<TagDTO>>>
    {
        public async Task<Result<IList<TagDTO>>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tags = await tagRepository.GetAllAsync(
                   a => a.OrderBy(e => e.Name),
                   cancellationToken);

                var data = mapper.Map<IList<TagDTO>>(tags.ToArray());
                return Result<IList<TagDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all tag data");
                return Result<IList<TagDTO>>.Failure("GetAllTags.Exception", ex.Message);
            }
        }
    }
}
