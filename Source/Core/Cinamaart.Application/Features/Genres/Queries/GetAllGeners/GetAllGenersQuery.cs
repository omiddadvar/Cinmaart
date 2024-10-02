using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Genres.Queries.GetAllGeners
{
    public record GetAllGenersQuery : IRequest<Result<IList<GenreDTO>>>;
}
