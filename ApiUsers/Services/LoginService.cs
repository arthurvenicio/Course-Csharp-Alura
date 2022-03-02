using ApiUsers.Data.Requets;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace ApiUsers.Services
{
    public class LoginService
    {
        private TokenService _tokenService;
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result Login(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultIdentity.Result.Succeeded) {
                var identityResult = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == request.UserName.ToUpper());
                var token = _tokenService.CreateToken(identityResult);
                return Result.Ok().WithSuccess(token.Value);
            };
            return Result.Fail("Erro ao tentar fazer o login do usuario");
        }
    }
}
