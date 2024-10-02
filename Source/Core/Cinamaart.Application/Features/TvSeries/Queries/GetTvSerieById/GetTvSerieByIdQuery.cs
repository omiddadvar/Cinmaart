using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetTvSerieById
{
    public record GetTvSerieByIdQuery(int TvSerieId) : IRequest<Result<TvSerieDTO>>;

}
