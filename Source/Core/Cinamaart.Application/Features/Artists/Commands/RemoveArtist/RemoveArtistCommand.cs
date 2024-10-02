using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Artists.Commands.RemoveArtist
{
    public record RemoveArtistCommand(int ArtistId) : IRequest<WebServiceResult<bool>>;
}
