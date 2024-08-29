using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Tags.Queries.GetTagById
{
    public record GetTagByIdQuery(int Id) : IRequest<Result<TagDTO>>;
}
