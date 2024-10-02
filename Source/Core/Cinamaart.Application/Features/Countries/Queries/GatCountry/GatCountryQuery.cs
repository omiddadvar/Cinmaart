using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Countries.Queries.GatCountry
{
    public record GatCountryQuery(int Id) : IRequest<WebServiceResult<CountryDTO>>;
}
