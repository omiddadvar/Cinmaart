using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Movies.Commands.UpdateMovie
{
    public record UpdateMovieCommand(
        int Id,
        string Name,
        int Year,
        string Description,
        int? CountryId
    ) : IRequest<Result<MovieDTO>>;
}
