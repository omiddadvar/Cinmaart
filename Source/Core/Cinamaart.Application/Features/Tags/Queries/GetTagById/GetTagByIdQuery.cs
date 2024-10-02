using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Tags.Queries.GetTagById
{
    public record GetTagByIdQuery(int Id) : IRequest<Result<TagDTO>>;
}
