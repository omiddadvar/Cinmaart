using Cinamaart.Domain.Entities.Types;
using Cinamaart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Cinamaart.Application.Features.Artists.Queries;

namespace Cinamaart.Application.Features.Artists.Commands.AddArtist
{
    public record AddArtistCommand
    (
        string FullName,
        DateTime? BirthDate,
        int GenderId,
        int? CountryId
    )
    : IRequest<Result<GetArtistDTO>>;
}
