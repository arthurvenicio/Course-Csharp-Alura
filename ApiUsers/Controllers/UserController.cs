using ApiUsers.Data.Dtos.User;
using ApiUsers.Data.Requets;
using ApiUsers.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ApiUsers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private readonly ILogger _logger;
        

        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            Result result = _userService.CreateUser(userDto);
            if (result.IsFailed)
            {
                _logger.LogError(result.Errors.ToString());
                return StatusCode(500);
            }

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpGet("confirmation")]
        public IActionResult ConfirmationAccount([FromQuery] AccountConfirmationRequest request)
        {
            Result result = _userService.ConfirmationAccount(request);
            if(result.IsFailed) return StatusCode(500);
            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
