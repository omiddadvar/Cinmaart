using Cinamaart.WebAPI.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubtitleController : ControllerBase
    {
        [HttpGet("Movie/{id}")]
        [Authorize]
        public async Task<IActionResult> GetPaginatedSubtitlesByMovieId(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("Episode/{id}")]
        [Authorize]
        public async Task<IActionResult> GetPaginatedSubtitlesByEpisodeId(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Policy = PolicyNames.RequireSubtitleEditionAccess)]
        public async Task<IActionResult> AddSubtitle()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Authorize(Policy = PolicyNames.RequireSubtitleEditionAccess)]
        public async Task<IActionResult> EditSubtitle()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Authorize(Policy = PolicyNames.RequireSubtitleEditionAccess)]
        public async Task<IActionResult> RemoveSubtitle()
        {
            throw new NotImplementedException();
        }
    }
}
