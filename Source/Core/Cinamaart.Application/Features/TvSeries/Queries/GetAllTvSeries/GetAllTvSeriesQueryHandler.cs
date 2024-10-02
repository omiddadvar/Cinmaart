using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.TvSeries;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetAllTvSeries
{
    internal class GetAllTvSeriesQueryHandler(
            IMapper mapper,
            ITvSerieRepository tvSerieRepository,
            ILogger<GetAllTvSeriesQueryHandler> logger
        ) : IRequestHandler<GetAllTvSeriesQuery, WebServiceResult<IList<TvSerieDTO>>>
    {
        public async Task<WebServiceResult<IList<TvSerieDTO>>> Handle(GetAllTvSeriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await tvSerieRepository.GetAsync(
                    Where: null,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    a => a.Country);

                var data = mapper.Map<IList<TvSerieDTO>>(rawData.ToArray());
                return WebServiceResult<IList<TvSerieDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all TvSeries data");
                return WebServiceResult<IList<TvSerieDTO>>.Failure("GetAllTvSeries.Exception", ex.Message);
            }
        }
    }
}
