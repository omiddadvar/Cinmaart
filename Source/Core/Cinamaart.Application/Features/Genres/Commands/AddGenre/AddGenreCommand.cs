using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Genres.Commands.AddGenre
{
    public record AddGenreCommand(
            string Name
        ) : IRequest<Result<GenreDTO>>;
}
