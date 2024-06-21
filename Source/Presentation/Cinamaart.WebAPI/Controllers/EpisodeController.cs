using Cinamaart.WebAPI.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        [HttpGet("Paginate")]
        public async Task<IActionResult> GetPaginatedEpisodes()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]

        public async Task<IActionResult> AddEpisode()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]

        public async Task<IActionResult> EditEpisode()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]

        public async Task<IActionResult> DeleteEpisode()
        {
            throw new NotImplementedException();
        }
    }
}
