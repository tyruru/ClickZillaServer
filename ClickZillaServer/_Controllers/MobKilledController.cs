using System.Diagnostics;
using ClickZillaServer.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ClickZillaServer.Controllers;

[ApiController]
[Route("User")]
public class MobKilledController : ControllerBase
{
    private readonly UserService _userService;

    public MobKilledController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPut]
    public async Task<IActionResult> MobKilled([FromBody] MobKilledRequest mobKilledRequest)
    {
        Debug.Assert(mobKilledRequest != null, "Request cannot be null");
        var user = await _userService.GetByIdAsync(mobKilledRequest.UserId);
        
        // user.UserExp = mobKilledRequest.UserExp ?? user.UserExp;
        // user.EnemiesKilled = mobKilledRequest.EnemiesKilled ?? user.EnemiesKilled;

        await _userService.UpdateAsync(user);
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