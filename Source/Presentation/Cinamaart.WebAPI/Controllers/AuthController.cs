using Cinamaart.Application.Features.Authentication.Queries.Login;
using Cinamaart.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand command , CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
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
