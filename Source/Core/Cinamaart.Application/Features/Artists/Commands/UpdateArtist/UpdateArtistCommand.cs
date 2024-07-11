using Cinamaart.Application.Features.Artists.Commands.AddArtist;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Artists.Commands.UpdateArtist
{
    public record UpdateArtistCommand 
    (
        int Id,
        string FullName,
        DateTime? BirthDate,
        int GenderId,
        int? CountryId
    ) : IRequest<Result<GetArtistDTO>>;
}
