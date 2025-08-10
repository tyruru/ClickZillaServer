using ClickZillaServer.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ClickZillaServer.Controllers;

[ApiController]
[Route("User")]
public class AuthorizeController : ControllerBase
{
    private readonly UserService _userService;

    public AuthorizeController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Authorize")]
    public async Task<IActionResult> Authorize([FromBody] UserAuthorizeRequest request)
    {
        var isAuth = await _userService.AuthorizeAsync(request.UserName, request.Password);
        if (!isAuth)
            return Unauthorized("Invalid username or password");

        var user = await _userService.GetUserAsync(request.UserName);
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