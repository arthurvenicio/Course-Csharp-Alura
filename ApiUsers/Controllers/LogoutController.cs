using ApiUsers.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiUsers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Result result = _logoutService.Logout();
            if(result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok();
        }
    }
}
