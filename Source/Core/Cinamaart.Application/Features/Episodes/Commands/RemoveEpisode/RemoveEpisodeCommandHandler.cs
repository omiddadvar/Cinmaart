using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Episodes.Commands.RemoveEpisode
{
    internal class RemoveEpisodeCommandHandler(
            IEpisodeRepository episodeRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveEpisodeCommandHandler> logger
        ) : IRequestHandler<RemoveEpisodeCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveEpisodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await episodeRepository.DeleteAsync(request.EpisodeId);
                await unitOfWork.SaveAsync(cancellationToken);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing Episode, EpisodeId = {EpisodeId}", request.EpisodeId);
                return Result<bool>.Failure("RemoveEpisode.Exception", ex.Message);
            }
        }
    }
}
