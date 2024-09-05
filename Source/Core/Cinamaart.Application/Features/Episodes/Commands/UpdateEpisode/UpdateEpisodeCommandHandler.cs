using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Episodes.Commands.UpdateEpisode;
using Cinamaart.Application.Features.Episodes;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;

namespace Cinamaart.Application.Features.Episodes.Commands.UpdateEpisode
{
    internal class UpdateEpisodeCommandHandler(
            IMapper mapper,
            IEpisodeRepository episodeRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateEpisodeCommandHandler> logger
        ) : IRequestHandler<UpdateEpisodeCommand, Result<EpisodeDTO>>
    {
        public async Task<Result<EpisodeDTO>> Handle(UpdateEpisodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Episode = mapper.Map<Episode>(request);
                await episodeRepository.UpdateAsync(Episode);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<EpisodeDTO>(Episode);
                return Result<EpisodeDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while updating Episode, requested data = {request}", request.ToJson());
                return Result<EpisodeDTO>.Failure("UpdateEpisode.Exception", ex.Message);
            }
        }
    }
}
