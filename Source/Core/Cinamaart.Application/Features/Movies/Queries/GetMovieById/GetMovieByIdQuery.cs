using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Movies.Queries.GetMovieById
{
    public record GetMovieByIdQuery(int MovieId) : IRequest<Result<MovieDTO>>;
}
