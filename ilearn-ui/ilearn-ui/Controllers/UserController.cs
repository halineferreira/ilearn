using ilearn_ui.services;
using Microsoft.AspNetCore.Mvc;

namespace ilearn_ui.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.SearchUsersAsync());
        }
    }
}
