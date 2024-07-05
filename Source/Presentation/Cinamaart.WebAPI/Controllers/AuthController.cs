using Cinamaart.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<User> _userManager,
        RoleManager<Role> _roleManager) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register()
        {
            throw new NotImplementedException();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            throw new NotImplementedException();
        }
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh()
        {
            throw new NotImplementedException();
        }
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword()
        {
            throw new NotImplementedException();
        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail()
        {
            throw new NotImplementedException();
        }
    }
}
