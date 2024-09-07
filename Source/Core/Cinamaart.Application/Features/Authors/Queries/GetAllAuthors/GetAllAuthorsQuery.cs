using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authors.Queries.GetAllAuthors
{
    public record GetAllAuthorsQuery : IRequest<Result<IList<AuthorDTO>>>;
}
