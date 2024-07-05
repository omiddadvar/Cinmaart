using Cinamaart.Application.Features.Artists.Queries.GetAllArtists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetArtists(CancellationToken cancellationToken = default)
        {
            var query = new GetAllArtistsQuery();
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("Paginate")]
        public async Task<IActionResult> GetPaginatedArtists()
        {
            throw new NotImplementedException();
        }
        [HttpGet("Country/{id}")]
        public async Task<IActionResult> GetPaginatedArtistsByCountry(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtisById(long id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> AddArtist()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        public async Task<IActionResult> EditArtist()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveArtist()
        {
            throw new NotImplementedException();
        }
    }
}
