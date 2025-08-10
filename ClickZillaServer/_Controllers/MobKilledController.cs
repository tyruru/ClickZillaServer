using System.Diagnostics;
using ClickZillaServer.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ClickZillaServer.Controllers;

[ApiController]
[Route("MobKilled")]
public class MobKilledController : ControllerBase
{
    private readonly UserService _userService;
    private readonly EnemyService _enemyService;

    public MobKilledController(UserService userService, EnemyService enemyService)
    {
        _userService = userService;
        _enemyService = enemyService;
    }

    [HttpPut]
    public async Task<IActionResult> MobKilled([FromBody] MobKilledRequest mobKilledRequest)
    {
        Debug.Assert(mobKilledRequest != null, "Request cannot be null");
        var user = await _userService.GetByIdAsync(mobKilledRequest.UserId);
        var enemy = await _enemyService.GetEnemyByNameAsync(mobKilledRequest.EnemyName);
        Debug.Assert(user != null, "User not found");
        Debug.Assert(enemy != null, "Enemy not found");
        
        user.UserExp += enemy.Exp;
        user.EnemiesKilled++;

        await _userService.UpdateAsync(user);
        var mobKilledModel = new MobKilledModel
        {
           Exp = user.UserExp,
           EnemiesKilled = user.EnemiesKilled,
           CurrentEnemyName = enemy.Name,
           IsNewLocateUnlocked = false
        };
        return Ok(mobKilledModel);
    }
}