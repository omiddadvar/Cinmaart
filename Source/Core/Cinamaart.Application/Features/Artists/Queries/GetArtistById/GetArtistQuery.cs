using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Artists.Queries.GetArtistById
{
    public record GetArtistQuery(
        int ArtistId
    ) : IRequest<WebServiceResult<GetArtistDTO>>;
}
