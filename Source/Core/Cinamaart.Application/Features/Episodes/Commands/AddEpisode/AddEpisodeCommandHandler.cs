using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Episodes.Commands.AddEpisode
{
    internal class AddEpisodeCommandHandler(
            IMapper mapper,
            IEpisodeRepository episodeRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddEpisodeCommandHandler> logger
        ) : IRequestHandler<AddEpisodeCommand, WebServiceResult<EpisodeDTO>>
    {
        public async Task<WebServiceResult<EpisodeDTO>> Handle(AddEpisodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Episode = mapper.Map<Episode>(request);
                Episode = await episodeRepository.AddAsync(Episode);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<EpisodeDTO>(Episode);
                return WebServiceResult<EpisodeDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding Episode, requested data = {request}", request.ToJson());
                return WebServiceResult<EpisodeDTO>.Failure("AddEpisode.Exception", ex.Message);
            }
        }
    }
}
