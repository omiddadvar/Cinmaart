using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Seasons.Queries.GetSeasonById
{
    public record GetSeasonByIdQuery(int SeasonId) : IRequest<Result<SeasonDTO>>;
}
