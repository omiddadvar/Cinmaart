using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Tags.Queries.GetTagById
{
    internal class GetTagByIdQueryHandler(
            IMapper mapper,
            ITagRepository tagRepository,
            ILogger<GetTagByIdQueryHandler> logger
        ) : IRequestHandler<GetTagByIdQuery, Result<TagDTO>>
    {
        public async Task<Result<TagDTO>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await tagRepository.GetAsync(request.Id, cancellationToken);
                var data = mapper.Map<TagDTO>(tag);
                return Result<TagDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading tag data, tagid = {tag}", request.Id);
                return Result<TagDTO>.Failure("GetTagById.Exception", ex.Message);
            }
        }
    }
}
