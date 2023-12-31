using Entities.DataTransferObjects.UserDtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto, CancellationToken cancellationToken = default)
        {
            var result = await _userService.RegisterUserAsync(userForRegistrationDto, cancellationToken);

            return result.Succeeded ? StatusCode(201) : BadRequest(result);
        }
        [HttpPost("authorize")]
        public async Task<IActionResult> AuthorizeUserAsync(UserForAuthorizeDto userForAuthorizeDto, CancellationToken cancellationToken = default)
        {
            var jwt = await _userService.AuthorizeAsync(userForAuthorizeDto, cancellationToken);

            return jwt == null ? Unauthorized($"Invalid authenticate") : Ok(jwt);
        }
    }
}
