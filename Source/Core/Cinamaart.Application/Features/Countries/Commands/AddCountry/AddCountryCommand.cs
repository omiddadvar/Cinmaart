using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Countries.Commands.AddCountry
{
    public record AddCountryCommand(
            string Name
        )
        : IRequest<WebServiceResult<CountryDTO>>;
}
