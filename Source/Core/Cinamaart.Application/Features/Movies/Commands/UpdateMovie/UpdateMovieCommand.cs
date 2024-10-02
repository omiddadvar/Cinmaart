using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Movies.Commands.UpdateMovie
{
    public record UpdateMovieCommand(
        int Id,
        string Name,
        int Year,
        string Description,
        int? CountryId
    ) : IRequest<WebServiceResult<MovieDTO>>;
}
