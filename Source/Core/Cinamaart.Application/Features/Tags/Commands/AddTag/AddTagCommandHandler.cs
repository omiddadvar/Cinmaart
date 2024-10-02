using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Tags.Commands.AddTag
{
    internal class AddTagCommandHandler
        (
            IMapper mapper,
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddTagCommandHandler> logger
        ) : IRequestHandler<AddTagCommand, WebServiceResult<TagDTO>>
    {
        public async Task<WebServiceResult<TagDTO>> Handle(AddTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = mapper.Map<Tag>(request);
                tag = await tagRepository.AddAsync(tag);
                await unitOfWork.SaveAsync(cancellationToken);

                var tagDTO = mapper.Map<TagDTO>(tag);
                return WebServiceResult<TagDTO>.Success(tagDTO);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error while adding tag, requested data = {request}", request.ToJson());
                return WebServiceResult<TagDTO>.Failure("AddTag.Exception", ex.Message);
            }
        }
    }
}
