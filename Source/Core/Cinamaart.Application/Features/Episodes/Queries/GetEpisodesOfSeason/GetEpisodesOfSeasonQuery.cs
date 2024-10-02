using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Episodes.Queries.GetEpisodesOfSeason
{
    public record GetEpisodesOfSeasonQuery(int SeasonId) : IRequest<WebServiceResult<IList<EpisodeDTO>>>;
}
