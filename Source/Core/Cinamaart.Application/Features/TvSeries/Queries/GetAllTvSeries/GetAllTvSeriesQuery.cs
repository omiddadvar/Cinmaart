using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetAllTvSeries
{
    public record GetAllTvSeriesQuery : IRequest<Result<IList<TvSerieDTO>>>;
}
