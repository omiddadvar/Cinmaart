using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetPaginatedTvSeries
{
    internal class GetPaginatedTvSeriesQueryHandler(
            IMapper mapper,
            ITvSerieRepository tvSerieRepository,
            ILogger<GetPaginatedTvSeriesQueryHandler> logger
        ) : IRequestHandler<GetPaginatedTvSerieQuery, Result<PagedList<TvSerieDTO>>>
    {
        public async Task<Result<PagedList<TvSerieDTO>>> Handle(GetPaginatedTvSerieQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<TvSerie, bool>> Where =
                    m => (string.IsNullOrWhiteSpace(request.NameSearchKeyword) || m.Name.Contains(request.NameSearchKeyword))
                    && (request.Countries == null || request.Countries.Contains(m.CountryId.Value));

                var rawData = await tvSerieRepository.PaginateAsync(
                    page: request.Page,
                    pageSize: request.PageSize,
                    Where: Where,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    e => e.Country);

                var data = mapper.Map<PagedList<TvSerie>, PagedList<TvSerieDTO>>(rawData);
                return Result<PagedList<TvSerieDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading paginated TvSerie data, requested data = {request}", request.ToJson());
                return Result<PagedList<TvSerieDTO>>.Failure("GetPaginatedTvSeries.Exception", ex.Message);
            }
        }
    }
}
