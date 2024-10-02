using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Features.Artists.Queries;
using MediatR;

namespace Cinamaart.Application.Features.Artists.Commands.UpdateArtist
{
    public record UpdateArtistCommand
    (
        int Id,
        string FullName,
        DateTime? BirthDate,
        int GenderId,
        int? CountryId
    ) : IRequest<WebServiceResult<GetArtistDTO>>;
}
