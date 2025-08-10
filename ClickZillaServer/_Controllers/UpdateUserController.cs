using System.Diagnostics;
using ClickZillaServer.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ClickZillaServer.Controllers;

[ApiController]
[Route("User")]
public class UpdateUserController : ControllerBase
{
    private readonly UserService _userService;

    public UpdateUserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateRequest)
    {
        Debug.Assert(updateRequest != null, "User model cannot be null");
        var user = await _userService.GetUserAsync(updateRequest.UserId);

        user.UserExp = updateRequest.UserExp ?? user.UserExp;
        user.EnemiesKilled = updateRequest.EnemiesKilled ?? user.EnemiesKilled;

        await _userService.UpdateUserAsync(user);
        var userModel = new UserModel
        {
            UserId = user.Id,
            UserName = user.UserName,
            UserExp = user.UserExp,
            EnemiesKilled = user.EnemiesKilled
        };
        return Ok(userModel);
    }
}