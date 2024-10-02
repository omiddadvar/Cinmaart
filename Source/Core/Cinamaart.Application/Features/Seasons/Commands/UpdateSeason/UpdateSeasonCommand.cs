using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Seasons.Commands.UpdateSeason
{
    public record UpdateSeasonCommand(
        int Id,
        string Name,
        int Year,
        string Description,
        int TvSerieId
    ) : IRequest<Result<SeasonDTO>>;
}
