using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Seasons.Queries.GetAllSeasonsOfTvSerie
{
    public record GetAllSeasonsOfTvSerieQuery(int TvSerieId) : IRequest<WebServiceResult<IList<SeasonDTO>>>;
}
