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

        [HttpGet("{subject}")]
        public async Task<IActionResult> SearchBySubject(string subject)
        {
            return Ok(await _userService.SearchBySubjectAsync(subject));
        }

        [HttpGet("{subject}/{location}")]
        public async Task<IActionResult> SearchBySubject(string subject, string location)
        {
            return Ok(await _userService.SearchBySubjectAndLocationAsync(subject, location));
        }
    }
}
