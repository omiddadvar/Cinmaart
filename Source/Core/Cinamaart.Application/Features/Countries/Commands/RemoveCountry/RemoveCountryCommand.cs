using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Countries.Commands.RemoveCountry
{
    public record RemoveCountryCommand(
            int Id
        )
        : IRequest<WebServiceResult<bool>>;
}
