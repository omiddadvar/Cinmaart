using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Seasons.Commands.AddSeason
{
    public record AddSeasonCommand(
            string Name,
            int Year,
            string Description,
            int TvSerieId
        ) : IRequest<WebServiceResult<SeasonDTO>>;
}
