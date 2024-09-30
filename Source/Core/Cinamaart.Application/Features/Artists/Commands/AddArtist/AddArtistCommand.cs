
using MediatR;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Abstractions;

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
