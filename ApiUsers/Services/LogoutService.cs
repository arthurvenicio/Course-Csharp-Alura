using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;

namespace ApiUsers.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Logout()
        {
            var result = _signInManager.SignOutAsync();
            if (result.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Erro ao deslogar o usuario!");

        }
    }
}
