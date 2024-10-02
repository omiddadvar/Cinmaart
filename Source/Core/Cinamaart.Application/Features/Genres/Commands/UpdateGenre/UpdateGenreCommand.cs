using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Genres.Commands.UpdateGenre
{
    public record UpdateGenreCommand(
            int Id,
            string Name
        ) : IRequest<Result<GenreDTO>>;
}
