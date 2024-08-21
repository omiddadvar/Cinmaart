using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Genres.Commands.UpdateGenre
{
    public record UpdateGenreCommand(
            int Id,
            string Name
        ) : IRequest<Result<GenreDTO>>;
}
