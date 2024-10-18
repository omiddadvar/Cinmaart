using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Movies.Commands.AddMovie
{
    public record AddMovieCommand(
            string Name,
            int Year,
            string Description,
            int? CountryId
        ) : IRequest<WebServiceResult<MovieDTO>>;
}
