using Cinamaart.WebAPI.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Role])]
        public async Task<IActionResult> GetRoles()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Role])]

        public async Task<IActionResult> GetRoleById(long id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> AddRole()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Role, CancellationToken.None);
            return null;
        }
        [HttpPut]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> EditRole()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Role, CancellationToken.None);
            return null;
        }
        [HttpDelete]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> DeleteRole()
        {
            await cacheStore.EvictByTagAsync(CacheTags.Role, CancellationToken.None);
            return null;
        }
    }
}
