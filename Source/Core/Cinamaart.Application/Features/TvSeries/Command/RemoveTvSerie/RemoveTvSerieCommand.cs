using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.TvSeries.Command.RemoveTvSerie
{
    public record RemoveTvSerieCommand(int TvSerieId) : IRequest<WebServiceResult<bool>>;
}
