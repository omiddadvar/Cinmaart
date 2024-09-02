using Cinamaart.WebAPI.Abstractions.Constants;
using Cinamaart.Application.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Cinamaart.Domain.Abstractions;
using Cinamaart.WebAPI.Abstractions;
using Cinamaart.Application.Features.Genres.Queries.GetAllGeners;
using System.Threading;
using Cinamaart.Application.Features.Tags.Queries.GetAllTags;
using Cinamaart.Application.Features.Genres.Queries.GetGenreById;
using Cinamaart.Application.Features.Tags.Queries.GetTagById;
using Cinamaart.Application.Features.Tags.Commands.AddTag;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Cinamaart.Application.Features.Tags.Commands.UpdateTag;
using Cinamaart.Application.Features.Tags.Commands.RemoveTag;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController(IMediator mediator, IOutputCacheStore cacheStore) : CinamaartBaseController(cacheStore)
    {
        [HttpGet]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Tag])]
        public async Task<IActionResult> GetTags(CancellationToken cancellationToken = default)
        {
            var query = new GetAllTagsQuery();
            var data = await mediator.Send(query, cancellationToken);
            return data.IsSuccess ? Ok(data) : BadRequest(data);
        }
        [HttpGet("{id}")]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Tag])]

        public async Task<IActionResult> GetTagById(int id, CancellationToken cancellationToken = default)
        {
            var query = new GetTagByIdQuery(id);
            var data = await mediator.Send(query, cancellationToken);
            return data.IsSuccess ? Ok(data) : BadRequest(data);
        }
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]

        public async Task<IActionResult> AddTag(AddTagCommand command,CancellationToken cancellationToken = default)
        {
            var data = await mediator.Send(command, cancellationToken);
            return await runAfterCommandOperationWithCacheReset(data, CacheTags.Tag);
        }
        [HttpPut]
        [Authorize(Roles = RoleNames.Administrator)]

        public async Task<IActionResult> EditTag(UpdateTagCommand command,CancellationToken cancellationToken = default)
        {
            var data = await mediator.Send(command, cancellationToken);
            return await runAfterCommandOperationWithCacheReset(data, CacheTags.Tag);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleNames.Administrator)]

        public async Task<IActionResult> DeleteTag(int id,, CancellationToken cancellationToken = default)
        {
            var command = new RemoveTagCommand(id);
            var data = await mediator.Send(command, cancellationToken);
            return await runAfterCommandOperationWithCacheReset(data , CacheTags.Tag);
        }
    }
}
