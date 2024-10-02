using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetTvSerieById
{
    internal class GetTvSerieByIdQueryHandler(
        IMapper mapper,
        ITvSerieRepository tvSerieRepository,
        ILogger<GetTvSerieByIdQueryHandler> logger
    ) : IRequestHandler<GetTvSerieByIdQuery, Result<TvSerieDTO>>
    {
        public async Task<Result<TvSerieDTO>> Handle(GetTvSerieByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await tvSerieRepository.GetAsync(request.TvSerieId, cancellationToken);
                var data = mapper.Map<TvSerieDTO>(artist);
                return Result<TvSerieDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading TvSerie data, TvSerieid = {TvSerieid}", request.TvSerieId);
                return Result<TvSerieDTO>.Failure("GetTvSerieById.Exception", ex.Message);
            }
        }
    }
}
