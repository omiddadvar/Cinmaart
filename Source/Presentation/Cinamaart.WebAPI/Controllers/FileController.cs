using Cinamaart.Application.Abstractions.Constants;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using Cinamaart.WebAPI.Extentions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController(
            IMediator mediator,
            IStringLocalizer<StringResources> localizer
        ) : ControllerBase
    {
        [HttpGet("Profile/{UserId}")]
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
        public async Task<IActionResult> AddSubtitleFile([FromForm] IFormFile file, [FromForm] long SubtitleId)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("SubtitleFile/{id}")]
        [Authorize(Policy = PolicyNames.RequireSubtitleEditionAccess)]
        public async Task<IActionResult> RemoveSubtitleFile(long id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("UserProfile")]
        [Authorize(Policy = PolicyNames.IsResourceOwnerOrAdmin)]
        public async Task<IActionResult> AddUserProfile([FromForm] IFormFile file , [FromForm] long UserId)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("UserProfile/{id}")]
        [Authorize(Policy = PolicyNames.IsResourceOwnerOrAdmin)]
        public async Task<IActionResult> RemoveUserProfile(long id)
        {
            bool isAccessOk = Request.HttpContext.IsSameUserOrAdmin(id);
            if (!isAccessOk)
            {
                return Unauthorized(Result<object>.Failure(localizer[LocalStringKeyword.UnAuthorized]))
            }
            throw new NotImplementedException();
        }
    }
}
