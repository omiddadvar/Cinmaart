using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Genres.Commands.RemoveGenre
{
    public record RemoveGenreCommand(int Id) : IRequest<Result<bool>>;
}
