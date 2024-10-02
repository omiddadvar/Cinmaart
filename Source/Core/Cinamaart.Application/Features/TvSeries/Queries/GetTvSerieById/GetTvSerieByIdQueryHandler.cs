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

namespace Cinamaart.Application.Features.TvSeries.Queries.GetTvSerieById
{
    internal class GetTvSerieByIdQueryHandler(
        IMapper mapper,
        ITvSerieRepository tvSerieRepository,
        ILogger<GetTvSerieByIdQueryHandler> logger
    ) : IRequestHandler<GetTvSerieByIdQuery, WebServiceResult<TvSerieDTO>>
    {
        public async Task<WebServiceResult<TvSerieDTO>> Handle(GetTvSerieByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await tvSerieRepository.GetAsync(request.TvSerieId, cancellationToken);
                var data = mapper.Map<TvSerieDTO>(artist);
                return WebServiceResult<TvSerieDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading TvSerie data, TvSerieid = {TvSerieid}", request.TvSerieId);
                return WebServiceResult<TvSerieDTO>.Failure("GetTvSerieById.Exception", ex.Message);
            }
        }
    }
}
