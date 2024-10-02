using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetAllTvSeries
{
    internal class GetAllTvSeriesQueryHandler(
            IMapper mapper,
            ITvSerieRepository tvSerieRepository,
            ILogger<GetAllTvSeriesQueryHandler> logger
        ) : IRequestHandler<GetAllTvSeriesQuery, Result<IList<TvSerieDTO>>>
    {
        public async Task<Result<IList<TvSerieDTO>>> Handle(GetAllTvSeriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await tvSerieRepository.GetAsync(
                    Where: null,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    a => a.Country);

                var data = mapper.Map<IList<TvSerieDTO>>(rawData.ToArray());
                return Result<IList<TvSerieDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all TvSeries data");
                return Result<IList<TvSerieDTO>>.Failure("GetAllTvSeries.Exception", ex.Message);
            }
        }
    }
}
