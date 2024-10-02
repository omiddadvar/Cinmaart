using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Episodes.Commands.RemoveEpisode
{
    public record RemoveEpisodeCommand(int EpisodeId) : IRequest<WebServiceResult<bool>>;
}
