using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinamaart.Application.Features.Episodes.Queries.GetEpisodesOfEpisode;
using Cinamaart.Application.Features.Episodes;
using Cinamaart.Application.Features.Episodes.Queries.GetEpisodesOfSeason;

namespace Cinamaart.Application.Features.Episodes.Queries.GetEpisodesOfEpisode
{
    internal class GetEpisodesOfEpisodeQueryHandler(
            IMapper mapper,
            IEpisodeRepository episodeRepository,
            ILogger<GetEpisodesOfEpisodeQueryHandler> logger
        ) : IRequestHandler<GetEpisodesOfSeasonQuery, Result<IList<EpisodeDTO>>>
    {
        public async Task<Result<IList<EpisodeDTO>>> Handle(GetEpisodesOfSeasonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await episodeRepository.GetAsync(
                    Where: s => s.SeasonId == request.SeasonId,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    a => a.Season);

                var data = mapper.Map<IList<EpisodeDTO>>(rawData.ToArray());
                return Result<IList<EpisodeDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all Episodes data");
                return Result<IList<EpisodeDTO>>.Failure("GetAllEpisodes.Exception", ex.Message);
            }
        }
    }
}
