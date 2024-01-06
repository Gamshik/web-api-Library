using Contracts.Managers;
using Contracts.Services;
using Entities.DataTransferObjects.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoggerManager _loggerManager;
        public UserController(IUserService userService, ILoggerManager loggerManager)
        {
            _userService = userService;
            _loggerManager = loggerManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request to register a user with email = '{userForRegistrationDto.Email}'!");

            var result = await _userService.RegisterUserAsync(userForRegistrationDto, cancellationToken);

            if (result.Succeeded)
            {
                _loggerManager.LogInfo($"User with email = '{userForRegistrationDto.Email}' has been registered!");

                return StatusCode(201);
            }

            _loggerManager.LogInfo($"User with email = '{userForRegistrationDto.Email}' has not been registered!");

            return BadRequest(result);
        }
        [HttpPost("authorize")]
        public async Task<IActionResult> AuthorizeUserAsync(UserForAuthorizeDto userForAuthorizeDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request to authorize a user with email = '{userForAuthorizeDto.Email}'!");

            var jwt = await _userService.AuthorizeAsync(userForAuthorizeDto, cancellationToken);

            if (jwt != null)
            {
                _loggerManager.LogInfo($"User with email = '{userForAuthorizeDto.Email}' has been authorized!");

                return Ok(jwt);
            }

            _loggerManager.LogInfo($"User with email = '{userForAuthorizeDto.Email}' has not been authorized!");

            return Unauthorized($"Invalid authenticate");
        }
    }
}
