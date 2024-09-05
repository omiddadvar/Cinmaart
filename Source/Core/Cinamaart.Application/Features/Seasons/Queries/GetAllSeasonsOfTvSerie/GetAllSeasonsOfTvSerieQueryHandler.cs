using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Seasons.Queries.GetAllSeasonsOfTvSerie
{
    internal class GetAllSeasonsOfTvSerieQueryHandler(
            IMapper mapper,
            ISeasonRepository SeasonRepository,
            ILogger<GetAllSeasonsOfTvSerieQueryHandler> logger
        ) : IRequestHandler<GetAllSeasonsOfTvSerieQuery, Result<IList<SeasonDTO>>>
    {
        public async Task<Result<IList<SeasonDTO>>> Handle(GetAllSeasonsOfTvSerieQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await SeasonRepository.GetAsync(
                    Where: s => s.TvSerieId == request.TvSerieId,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    a => a.TvSerie);

                var data = mapper.Map<IList<SeasonDTO>>(rawData.ToArray());
                return Result<IList<SeasonDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all Seasons data");
                return Result<IList<SeasonDTO>>.Failure("GetAllSeasons.Exception", ex.Message);
            }
        }
    }
}
