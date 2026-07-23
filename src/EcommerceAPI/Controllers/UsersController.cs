using Ecommerce.Application.Users.UserCommands.ChangePassword;
using Ecommerce.Application.Users.UserCommands.ForgotPassword;
using Ecommerce.Application.Users.UserCommands.Register;
using Ecommerce.Application.Users.UserCommands.ResetPassword;
using Ecommerce.Application.Users.UserQueries.GetCurrentUser;
using Ecommerce.Application.Users.UserQueries.VerifyEmail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(ISender sender) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterCommand command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginCommand command)
    {
        var result = await sender.Send(command);
        return Ok(result);
    }
    
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(
    ForgotPasswordCommand command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(
    ResetPasswordCommand command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }

    [Authorize]

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile(
    [FromBody] UpdateProfileCommand command)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        command.UserId = Guid.Parse(userId);

        var result = await sender.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    [Authorize]
    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword(
   [FromBody] ChangePasswordCommand command)
    {
        var userId = User.FindFirst(
            ClaimTypes.NameIdentifier)?.Value;


        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }


        command.UserId = Guid.Parse(userId);


        var result = await sender.Send(command);


        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }


        return Ok(result);
    }
    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }


        var result = await sender.Send(
            new GetCurrentUserQuery
            {
                UserId = Guid.Parse(userId)
            });


        return Ok(result);
    }
    [HttpGet("verify-email")]
    public async Task<IActionResult> VerifyEmail([FromQuery] string token)
    {
        var result = await sender.Send(
            new VerifyEmailCommand
            {
                Token = token
            });

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
   
}
