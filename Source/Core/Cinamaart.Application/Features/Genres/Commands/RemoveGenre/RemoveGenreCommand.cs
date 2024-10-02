using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Genres.Commands.RemoveGenre
{
    public record RemoveGenreCommand(int Id) : IRequest<Result<bool>>;
}
