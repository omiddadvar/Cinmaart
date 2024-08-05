using Cinamaart.Application.Abstractions.Constants;
using Cinamaart.WebAPI.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Genre])]
        public async Task<IActionResult> GetAllGenres()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Genre], VaryByQueryKeys = ["id"])]
        public async Task<IActionResult> GetGenre(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> AddGenre()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Genre, CancellationToken.None);
            return null;
        }
        [HttpPut]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> UpdateGenre()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Genre, CancellationToken.None);
            return null;
        }
        [HttpDelete]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> RemoveGenre()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Genre, CancellationToken.None);
            return null;
        }
    }
}
