using ClickZillaServer.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ClickZillaServer.Controllers;

[ApiController] 
[Route("Leaderboard")]
public class LeaderboardController : ControllerBase
{
    private readonly UserService _userService;

    public LeaderboardController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLeaderboard()
    {
        var users = await _userService.GetAllUsersAsync();

        var leaderboardEntity = users.OrderByDescending(u => u.UserExp).ToList().AsEnumerable();

        var leaderboardModel = new List<LeaderboardViewModel>();

        foreach (var user in leaderboardEntity)
        {
            leaderboardModel.Add(new LeaderboardViewModel
            {
                UserName = user.UserName,
                UserExp = user.UserExp,
            });
        }

        return Ok(leaderboardModel);
    }
}