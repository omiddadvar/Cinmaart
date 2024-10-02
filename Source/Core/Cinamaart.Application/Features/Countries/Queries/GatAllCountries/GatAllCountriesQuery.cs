using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Countries.Queries.GatAllCountries
{
    public record GatAllCountriesQuery() : IRequest<WebServiceResult<IList<CountryDTO>>>;
}
