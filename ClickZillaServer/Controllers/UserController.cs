using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClickZillaServer.Models;
using Services;
using Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClickZillaServer.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetTestUser()
        {
            var user = new UserModel
            {
                UserName = "TestUser",
                UserExp = 100,
                EnemiesKilled = 5,
            };
            return Ok(user);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _userService.GetAllUsersAsync();
            var user = new UserModel
            {
                UserName = "TestUser",
                UserExp = 40,
                EnemiesKilled = 4,
            };
            return Ok(user);
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

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateModel)
        {
            Debug.Assert(updateModel != null, "User model cannot be null");
            var user = await _userService.GetUserAsync(updateModel.UserId);

            user.UserExp = updateModel.UserExp ?? user.UserExp;
            user.EnemiesKilled = updateModel.EnemiesKilled ?? user.EnemiesKilled;

            await _userService.UpdateUserAsync(user);
            return Ok();
        }
    }
}
