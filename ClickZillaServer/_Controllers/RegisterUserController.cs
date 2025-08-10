using System.Diagnostics;
using ClickZillaServer.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ClickZillaServer.Controllers;

[ApiController]
[Route("User")]
public class RegisterUserController : ControllerBase
{
    private readonly UserService _userService;

    public RegisterUserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        Debug.Assert(request != null, "Request cannot be null");
        var users = await _userService.GetAllUsersAsync();
        if (users.Any(u => u.UserName == request.UserName))
            return BadRequest("User already exists");
        var userEntity = new User
        {
            UserName = request.UserName,
            UserExp = 0,
            EnemiesKilled = 0,
            Password = _userService.HashPassword(request.Password)
        };
        await _userService.AddUserAsync(userEntity);
        return Ok();
    }
}