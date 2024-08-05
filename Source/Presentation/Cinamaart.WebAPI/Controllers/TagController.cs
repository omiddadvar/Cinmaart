using Cinamaart.WebAPI.Abstractions.Constants;
using Cinamaart.Application.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Tag])]
        public async Task<IActionResult> GetTags()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Tag])]

        public async Task<IActionResult> GetTagById(long id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]

        public async Task<IActionResult> AddTag()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Tag, CancellationToken.None);
            return null;
        }
        [HttpPut]
        [Authorize(Roles = RoleNames.Administrator)]

        public async Task<IActionResult> EditTag()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Tag, CancellationToken.None);
            return null;
        }
        [HttpDelete]
        [Authorize(Roles = RoleNames.Administrator)]

        public async Task<IActionResult> DeleteTag()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Tag, CancellationToken.None);
            return null;
        }
    }
}
