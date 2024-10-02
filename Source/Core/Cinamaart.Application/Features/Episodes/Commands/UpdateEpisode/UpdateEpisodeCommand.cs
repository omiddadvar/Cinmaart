using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Episodes.Commands.UpdateEpisode
{
    public record UpdateEpisodeCommand(
        int Id,
        string Name,
        string Description,
        int SeasonId
    ) : IRequest<WebServiceResult<EpisodeDTO>>;
}
