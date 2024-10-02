using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Movies.Commands.RemoveMovie
{
    public record RemoveMovieCommand(int MovieId) : IRequest<Result<bool>>;
}
