﻿using Api.Models.Data;
using Api.Services;
using Api.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    // TODO Add Basic Auth
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(
        [FromServices] IJwtService jwtService,
        [FromServices] IUserService userService,
        [FromBody] User user)
    {
        try
        {
            var userFromDatabase = await userService.GetByIdAsync(user.Id);
            if (!userFromDatabase.PasswordMatch(user.Password))
            {
                return Unauthorized();
            }
            var token = jwtService.GenerateToken(userFromDatabase);
            return Ok(new { user = userFromDatabase, token });
        }
        catch (NotFoundException)
        {
            return Unauthorized();
        }
    }
}