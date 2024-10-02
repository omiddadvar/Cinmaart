
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Features.Artists.Queries;
using MediatR;

namespace Cinamaart.Application.Features.Artists.Commands.AddArtist
{
    public record AddArtistCommand
    (
        string FullName,
        DateTime? BirthDate,
        int GenderId,
        int? CountryId
    )
    : IRequest<WebServiceResult<GetArtistDTO>>;
}
