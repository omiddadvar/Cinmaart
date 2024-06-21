using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("SubtitleFile")]
        public async Task<IActionResult> AddSubtitleFile()
        {
            throw new NotImplementedException();
        }
        [HttpDelete("SubtitleFile")]
        public async Task<IActionResult> RemoveSubtitleFile()
        {
            throw new NotImplementedException();
        }
        [HttpPost("UserProfile")]
        public async Task<IActionResult> AddUserProfile()
        {
            throw new NotImplementedException();
        }
        [HttpDelete("UserProfile")]
        public async Task<IActionResult> RemoveUserProfile()
        {
            throw new NotImplementedException();
        }
    }
}
