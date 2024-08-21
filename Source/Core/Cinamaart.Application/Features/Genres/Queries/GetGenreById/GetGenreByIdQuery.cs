using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Genres.Queries.GetGenreById
{
    public record GetGenreByIdQuery(int Id) : IRequest<Result<GenreDTO>>;
}
