using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Genres.Queries.GetGenreById
{
    public record GetGenreByIdQuery(int Id) : IRequest<Result<GenreDTO>>;
}
