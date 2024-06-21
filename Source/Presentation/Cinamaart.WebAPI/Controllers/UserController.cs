using Cinamaart.WebAPI.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(long id)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditUser(int id)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> RemoveUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
