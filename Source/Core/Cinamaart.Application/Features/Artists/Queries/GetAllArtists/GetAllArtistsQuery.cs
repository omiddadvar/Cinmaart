using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Artists.Queries.GetAllArtists
{
    public record GetAllArtistsQuery : IRequest<Result>;
}
