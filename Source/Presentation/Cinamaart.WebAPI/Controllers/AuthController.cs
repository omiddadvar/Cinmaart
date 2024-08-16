using Cinamaart.Application.Features.Authentication.Commands.ConfirmEmail;
using Cinamaart.Application.Features.Authentication.Commands.Login;
using Cinamaart.Application.Features.Authentication.Commands.Refresh;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand query , CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : Unauthorized(result);
        }
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(RefreshCommand query , CancellationToken cancellationToken = default)
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
        public async Task<IActionResult> ConfirmEmail(long userId, string token , CancellationToken cancellationToken = default)
        {
            var command = new ConfirmEmailCommand(userId, token);
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
