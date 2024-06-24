using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            throw new NotImplementedException();
        }
        [HttpGet("Paginate")]
        public async Task<IActionResult> GetPaginatedArtists()
        {
            throw new NotImplementedException();
        }
        [HttpGet("Country/{id}")]
        public async Task<IActionResult> GetArtistsByCountry(int id)
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
