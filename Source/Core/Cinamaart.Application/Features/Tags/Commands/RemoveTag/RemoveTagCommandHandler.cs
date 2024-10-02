using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Tags.Commands.RemoveTag
{
    internal class RemoveTagCommandHandler(
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveTagCommandHandler> logger
        ) : IRequestHandler<RemoveTagCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await tagRepository.DeleteAsync(request.Id);
                await unitOfWork.SaveAsync(cancellationToken);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing tag, genreId = {Id}", request.Id);
                return Result<bool>.Failure("RemoveTag.Exception", ex.Message);
            }
        }
    }
}
