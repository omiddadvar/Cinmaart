using Cinamaart.Application.Abstractions.Constants;
using Cinamaart.Application.Features.Genres.Commands.AddGenre;
using Cinamaart.Application.Features.Genres.Commands.RemoveGenre;
using Cinamaart.Application.Features.Genres.Commands.UpdateGenre;
using Cinamaart.Application.Features.Genres.Queries.GetAllGeners;
using Cinamaart.Application.Features.Genres.Queries.GetGenreById;
using Cinamaart.WebAPI.Abstractions;
using Cinamaart.WebAPI.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(IMediator mediator, IOutputCacheStore cacheStore) : CinamaartBaseController(cacheStore)
    {
        [HttpGet]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Genre])]
        public async Task<IActionResult> GetAllGenres(CancellationToken cancellationToken = default)
        {
            var query = new GetAllGenersQuery();
            var data = await mediator.Send(query, cancellationToken);
            return data.IsSuccess ? Ok(data) : BadRequest(data);
        }
        [HttpGet("{id}")]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Genre], VaryByQueryKeys = ["id"])]
        public async Task<IActionResult> GetGenre(int id, CancellationToken cancellationToken = default)
        {
            var query = new GetGenreByIdQuery(id);
            var data = await mediator.Send(query, cancellationToken);
            return data.IsSuccess ? Ok(data) : BadRequest(data);
        }
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> AddGenre(AddGenreCommand command, CancellationToken cancellationToken = default)
        {
            var data = await mediator.Send(command, cancellationToken);
            return await runAfterCommandOperationWithCacheReset(data);
        }
        [HttpPut]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> UpdateGenre(UpdateGenreCommand command, CancellationToken cancellationToken = default)
        {
            var data = await mediator.Send(command, cancellationToken);
            return await runAfterCommandOperationWithCacheReset(data);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> RemoveGenre(int id,, CancellationToken cancellationToken = default)
        {
            var command = new RemoveGenreCommand(id);
            var data = await mediator.Send(command, cancellationToken);
            return await runAfterCommandOperationWithCacheReset(data);
        }

    }
}
