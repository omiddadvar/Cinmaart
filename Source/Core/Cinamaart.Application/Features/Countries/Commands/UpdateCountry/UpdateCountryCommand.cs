using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Countries.Commands.UpdateCountry
{
    public record UpdateCountryCommand(
            int Id,
            string Name
        )
        : IRequest<WebServiceResult<CountryDTO>>;
}
