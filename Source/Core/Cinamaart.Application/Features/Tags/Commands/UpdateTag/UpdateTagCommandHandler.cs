using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Tags.Commands.UpdateTag
{
    internal class UpdateTagCommandHandler(
            IMapper mapper,
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateTagCommandHandler> logger
        ) : IRequestHandler<UpdateTagCommand, Result<TagDTO>>
    {
        public async Task<Result<TagDTO>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = mapper.Map<Tag>(request);
                await tagRepository.UpdateAsync(tag);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<TagDTO>(tag);
                return Result<TagDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while editing tag, requested data = {request}", request.ToJson());
                return Result<TagDTO>.Failure("UpdateTag.Exception", ex.Message);
            }
        }
    }
}
