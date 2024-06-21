using Cinamaart.WebAPI.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("Profile/{UserId}")]
        [Authorize]
        public async Task<IActionResult> GetProfilePictureByUserId(long UserId)
        {
            throw new NotImplementedException();
        }
        [HttpGet("Subtitle/{SubtitleId}")]
        [Authorize]
        public async Task<IActionResult> GetFileBySubtitleId(long SubtitleId)
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetFileById(long id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("SubtitleFiles")]
        [Authorize(Policy = PolicyNames.RequireSubtitleEditionAccess)]
        public async Task<IActionResult> AddSubtitleFiles()
        {
            throw new NotImplementedException();
        }
        [HttpDelete("SubtitleFile")]
        [Authorize(Policy = PolicyNames.RequireSubtitleEditionAccess)]
        public async Task<IActionResult> RemoveSubtitleFile()
        {
            throw new NotImplementedException();
        }
        [HttpPost("UserProfile")]
        [Authorize]
        public async Task<IActionResult> AddUserProfile()
        {
            throw new NotImplementedException();
        }
        [HttpDelete("UserProfile")]
        [Authorize]
        public async Task<IActionResult> RemoveUserProfile()
        {
            throw new NotImplementedException();
        }
    }
}
