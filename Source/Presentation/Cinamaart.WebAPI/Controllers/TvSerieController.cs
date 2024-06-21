using Cinamaart.WebAPI.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvSerieController : ControllerBase
    {
        [HttpGet("Paginate")]
        public async Task<IActionResult> GetPaginatedTvSeries()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.TvSerie], VaryByQueryKeys = ["id"])]
        public async Task<IActionResult> GetTvSerieById(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]
        public async Task<IActionResult> AddTvSerie()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]
        public async Task<IActionResult> EditTvSerie()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]
        public async Task<IActionResult> RemoveTvSerie()
        {
            throw new NotImplementedException();
        }
    }
}
