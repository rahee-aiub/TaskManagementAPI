using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> RegisterUser([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registeredUser = await _userService.RegisterUser(user);
            return CreatedAtAction(nameof(GetUserById), new { userId = registeredUser.Id }, registeredUser);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<UserModel>> AuthenticateUser([FromBody] UserModel userAuth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authenticatedUser = await _userService.AuthenticateUser(userAuth.Username, userAuth.Password);

            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            return Ok(authenticatedUser);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserModel>> GetUserById(int userId)
        {
            // Add implementation to retrieve a user by ID if needed.
            // This action is included for reference purposes.
            // Adjust it based on your actual requirements.
            var user = new UserModel(); // Replace with actual logic to get user by ID
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
