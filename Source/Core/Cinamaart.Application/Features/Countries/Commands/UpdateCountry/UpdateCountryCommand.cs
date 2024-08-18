using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Countries.Commands.UpdateCountry
{
    public record UpdateCountryCommand(
            int Id,
            string Name
        )
        : IRequest<Result<CountryDTO>>;
}
