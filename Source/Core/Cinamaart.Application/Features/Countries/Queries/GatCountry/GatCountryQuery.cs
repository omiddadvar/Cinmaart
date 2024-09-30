using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Countries.Queries.GatCountry
{
    public record GatCountryQuery(int Id): IRequest<WebServiceResult<CountryDTO>>;
}
