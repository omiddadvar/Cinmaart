using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Countries.Commands.AddCountry
{
    public record AddCountryCommand(
            string Name
        ) 
        : IRequest<WebServiceResult<CountryDTO>>;
}
