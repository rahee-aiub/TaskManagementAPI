using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> RegisterUser(UserModel userModel)
        {
            return Ok(_userService.RegisterUser(userModel));
        }
    }
}
