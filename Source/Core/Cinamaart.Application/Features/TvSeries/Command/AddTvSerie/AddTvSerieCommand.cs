using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.TvSeries.Command.AddTvSerie
{
    public record AddTvSerieCommand(
        string Name,
        string Description,
        int? CountryId
        ) : IRequest<Result<TvSerieDTO>>;
}
