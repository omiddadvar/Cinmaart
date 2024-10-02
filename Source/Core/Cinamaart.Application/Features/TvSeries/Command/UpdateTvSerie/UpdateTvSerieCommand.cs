using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.TvSeries.Command.UpdateTvSerie
{
    public record UpdateTvSerieCommand(
            int Id,
            string Name,
            string Description,
            int? CountryId
        ) : IRequest<Result<TvSerieDTO>>;
}
