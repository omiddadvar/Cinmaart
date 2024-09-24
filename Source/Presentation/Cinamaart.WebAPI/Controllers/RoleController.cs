using Cinamaart.Application.Abstractions.Constants;
using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Features.Roles.Queries.GetUserRoles;
using Cinamaart.WebAPI.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Threading;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(
        IMediator mediator, 
        IOutputCacheStore cacheStore,
        IUserService userService) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Role])]
        public async Task<IActionResult> GetRoles()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Authorize]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Role])]

        public async Task<IActionResult> GetCurrentUserRoles(CancellationToken cancellationToken = default)
        {
            var userId = userService.GetUserId();
            var query = new GetUserRolesQuery(userId); 
            var data = await mediator.Send(query, cancellationToken);
            return data.IsSuccess ? Ok(data) : BadRequest(data);
        }
        [HttpGet("{userId}")]
        [Authorize]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Role])]

        public async Task<IActionResult> GetUserRoles(long userId, CancellationToken cancellationToken = default)
        {
            var query = new GetUserRolesQuery(userId);
            var data = await mediator.Send(query, cancellationToken);
            return data.IsSuccess ? Ok(data) : BadRequest(data);
        }
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]

        public async Task<IActionResult> AddRoleToUser(, CancellationToken cancellationToken = default)
        {
            return null;
        }
        [HttpPut]
        [Authorize(Roles = RoleNames.Administrator)]

        public async Task<IActionResult> RemoveRoleFromUser(, CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}
