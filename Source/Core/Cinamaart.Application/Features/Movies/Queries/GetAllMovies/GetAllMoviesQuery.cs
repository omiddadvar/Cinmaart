using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Movies.Queries.GetAllMovies
{
    public record GetAllMoviesQuery() : IRequest<Result<IList<MovieDTO>>>;
}
