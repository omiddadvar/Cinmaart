using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Movies.Queries.GetAllMovies
{
    public record GetAllMoviesQuery() : IRequest<Result<IList<MovieDTO>>>;
}
