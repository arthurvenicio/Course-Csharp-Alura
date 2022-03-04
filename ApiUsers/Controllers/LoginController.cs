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
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        private readonly ILogger _logger;

        public LoginController(LoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            Result result = _loginService.Login(request);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault().Message);
        }

        [HttpPost("request-reset")]
        public IActionResult RequestResetUser(RequestResetUser request)
        {
            Result result = _loginService.RequesetResetUser(request);
            if (result.IsFailed) return NotFound(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpPost("reset-user")]
        public IActionResult ResetUser(ResetUserRequest request)
        {
            Result result = _loginService.ResetUser(request);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
        }

    }
}
