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
                var token = _tokenService.CreateToken(identityResult, _signInManager.UserManager.GetRolesAsync(identityResult).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            };
            return Result.Fail("Erro ao tentar fazer o login do usuario");
        }

        public Result RequesetResetUser(RequestResetUser request)
        {
            var userId = GetUserByEmail(request.Email);
            if(userId == null) return Result.Fail("The user with this email was not found!");
            var tokenReset = _signInManager.UserManager.GeneratePasswordResetTokenAsync(userId).Result;
            return Result.Ok().WithSuccess(tokenReset);
        }

        public Result ResetUser(ResetUserRequest request)
        {
            IdentityUser<int> userId = GetUserByEmail(request.Email);
            if (userId == null) return Result.Fail("The user with this email was not found!");
            var reset = _signInManager.UserManager.ResetPasswordAsync(userId, request.Token, request.Password).Result;
            if (reset.Succeeded) return Result.Ok().WithSuccess("Password was changed with success!");
            return Result.Fail("The password cannot be changed!");
        }
        
        private IdentityUser<int> GetUserByEmail(string email)
        {
            IdentityUser<int> userId =
                _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
            return userId;
        }
    }
}
