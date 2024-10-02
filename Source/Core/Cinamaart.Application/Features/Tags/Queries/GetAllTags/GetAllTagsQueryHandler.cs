using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Tags.Queries.GetAllTags
{
    internal class GetAllTagsQueryHandler(
            IMapper mapper,
            ITagRepository tagRepository,
            ILogger<GetAllTagsQueryHandler> logger
        ) : IRequestHandler<GetAllTagsQuery, WebServiceResult<IList<TagDTO>>>
    {
        public async Task<WebServiceResult<IList<TagDTO>>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tags = await tagRepository.GetAllAsync(
                   a => a.OrderBy(e => e.Name),
                   cancellationToken);

                var data = mapper.Map<IList<TagDTO>>(tags.ToArray());
                return WebServiceResult<IList<TagDTO>>.Success(data);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error while reading all tag data");
                return WebServiceResult<IList<TagDTO>>.Failure("GetAllTags.Exception", ex.Message);
            }
        }
    }
}
