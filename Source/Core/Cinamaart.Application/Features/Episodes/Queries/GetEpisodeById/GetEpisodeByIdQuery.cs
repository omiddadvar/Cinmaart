using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Episodes.Queries.GetEpisodeById
{
    public record GetEpisodeByIdQuery(int EpisodeId) : IRequest<WebServiceResult<EpisodeDTO>>;
}
