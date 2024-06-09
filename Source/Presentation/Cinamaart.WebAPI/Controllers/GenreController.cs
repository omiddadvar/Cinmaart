using Cinamaart.WebAPI.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(IMediator mediator , IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Genre])]
        public async Task<IActionResult> GetAllGenres()
        {
            throw new NotImplementedException();
        }
        [HttpGet("id")]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Genre] , VaryByQueryKeys = ["id"])]
        public async Task<IActionResult> GetGenre(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddGenre()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Genre, CancellationToken.None);
            return null;
        }
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateGenre()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Genre, CancellationToken.None);
            return null;
        }
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteGenre()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Genre, CancellationToken.None);
            return null;
        }
    }
}
