using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Cinamaart.Application.Features.Episodes.Queries.GetEpisodesOfSeason;
using Cinamaart.Application.Abstractions;

namespace Cinamaart.Application.Features.Episodes.Queries.GetEpisodesOfEpisode
{
    internal class GetEpisodesOfEpisodeQueryHandler(
            IMapper mapper,
            IEpisodeRepository episodeRepository,
            ILogger<GetEpisodesOfEpisodeQueryHandler> logger
        ) : IRequestHandler<GetEpisodesOfSeasonQuery, WebServiceResult<IList<EpisodeDTO>>>
    {
        public async Task<WebServiceResult<IList<EpisodeDTO>>> Handle(GetEpisodesOfSeasonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await episodeRepository.GetAsync(
                    Where: s => s.SeasonId == request.SeasonId,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    a => a.Season);

                var data = mapper.Map<IList<EpisodeDTO>>(rawData.ToArray());
                return WebServiceResult<IList<EpisodeDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all Episodes data");
                return WebServiceResult<IList<EpisodeDTO>>.Failure("GetAllEpisodes.Exception", ex.Message);
            }
        }
    }
}
