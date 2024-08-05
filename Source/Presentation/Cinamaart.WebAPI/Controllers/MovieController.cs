using Cinamaart.Application.Abstractions.Constants;
using Cinamaart.WebAPI.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("Paginate")]
        public async Task<IActionResult> GetPaginatedMovies()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Movie], VaryByQueryKeys = ["id"])]
        public async Task<IActionResult> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]
        public async Task<IActionResult> AddMovie()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]
        public async Task<IActionResult> EditMovie()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]
        public async Task<IActionResult> RemoveMovie()
        {
            throw new NotImplementedException();
        }
    }
}
