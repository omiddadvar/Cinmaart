using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Countries.Queries.GatAllCountries
{
    public record GatAllCountriesQuery() : IRequest<WebServiceResult<IList<CountryDTO>>>;
}
