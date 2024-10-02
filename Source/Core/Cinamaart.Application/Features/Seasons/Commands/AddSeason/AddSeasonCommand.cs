using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Seasons.Commands.AddSeason
{
    public record AddSeasonCommand(
            string Name,
            int Year,
            string Description,
            int TvSerieId
        ) : IRequest<Result<SeasonDTO>>;
}
