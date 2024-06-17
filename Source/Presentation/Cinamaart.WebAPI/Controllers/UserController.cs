using Cinamaart.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserManager<User> _userManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddUser()
        {
            var result = await _userManager.CreateAsync(new User
            {
                Email = "omidGooooooooo@gmail.com"
            });
            return result.Succeeded ? Ok("User created") : BadRequest(result);
        }
    }
}
