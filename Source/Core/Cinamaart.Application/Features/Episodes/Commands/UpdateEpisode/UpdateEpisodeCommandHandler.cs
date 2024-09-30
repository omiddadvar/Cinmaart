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
using Cinamaart.Application.Abstractions;

namespace Cinamaart.Application.Features.Episodes.Commands.UpdateEpisode
{
    internal class UpdateEpisodeCommandHandler(
            IMapper mapper,
            IEpisodeRepository episodeRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateEpisodeCommandHandler> logger
        ) : IRequestHandler<UpdateEpisodeCommand, WebServiceResult<EpisodeDTO>>
    {
        public async Task<WebServiceResult<EpisodeDTO>> Handle(UpdateEpisodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Episode = mapper.Map<Episode>(request);
                await episodeRepository.UpdateAsync(Episode);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<EpisodeDTO>(Episode);
                return WebServiceResult<EpisodeDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while updating Episode, requested data = {request}", request.ToJson());
                return WebServiceResult<EpisodeDTO>.Failure("UpdateEpisode.Exception", ex.Message);
            }
        }
    }
}
