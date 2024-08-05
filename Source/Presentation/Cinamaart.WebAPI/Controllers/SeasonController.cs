using Cinamaart.Application.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        [HttpGet("Paginate")]
        public async Task<IActionResult> GetPaginatedSeasons()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]

        public async Task<IActionResult> AddSeason()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]

        public async Task<IActionResult> EditSeason()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Authorize(Policy = PolicyNames.RequireContentEditionAccess)]

        public async Task<IActionResult> DeleteSeason()
        {
            throw new NotImplementedException();
        }
    }
}
