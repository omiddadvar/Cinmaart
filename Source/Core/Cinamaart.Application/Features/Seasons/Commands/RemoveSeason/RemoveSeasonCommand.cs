using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Seasons.Commands.RemoveSeason
{
    public record RemoveSeasonCommand(int SeasonId) : IRequest<Result<bool>>;
}
