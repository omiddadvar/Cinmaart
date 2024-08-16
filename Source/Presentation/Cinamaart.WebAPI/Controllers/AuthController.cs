using Cinamaart.Application.Features.Authentication.Queries.Login;
using Cinamaart.Application.Features.Authentication.Queries.Refresh;
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
        public async Task<IActionResult> Login(LoginQuery query , CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : Unauthorized(result);
        }
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(RefreshQuery query , CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : Unauthorized(result);
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
