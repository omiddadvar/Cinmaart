using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Episodes.Commands.AddEpisode
{
    public record AddEpisodeCommand(
            string Name,
            string Description,
            int SeasonId
        ) : IRequest<WebServiceResult<EpisodeDTO>>;
}
