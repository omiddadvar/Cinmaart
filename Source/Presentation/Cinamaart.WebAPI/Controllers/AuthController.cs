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
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            throw new NotImplementedException();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            throw new NotImplementedException();
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            throw new NotImplementedException();
        }
        [HttpPost("forgetpassword")]
        public async Task<IActionResult> ForgetPassword()
        {
            throw new NotImplementedException();
        }
        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail()
        {
            throw new NotImplementedException();
        }
    }
}
