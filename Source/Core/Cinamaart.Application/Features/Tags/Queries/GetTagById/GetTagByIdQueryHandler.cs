using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Genres;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Tags.Queries.GetTagById
{
    internal class GetTagByIdQueryHandler(
            IMapper mapper,
            ITagRepository tagRepository,
            ILogger<GetTagByIdQueryHandler> logger
        ) : IRequestHandler<GetTagByIdQuery, WebServiceResult<TagDTO>>
    {
        public async Task<WebServiceResult<TagDTO>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await tagRepository.GetAsync(request.Id,cancellationToken);
                var data = mapper.Map<TagDTO>(tag);
                return WebServiceResult<TagDTO>.Success(data);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error while reading tag data, tagid = {tag}", request.Id);
                return WebServiceResult<TagDTO>.Failure("GetTagById.Exception", ex.Message);
            }
        }
    }
}
