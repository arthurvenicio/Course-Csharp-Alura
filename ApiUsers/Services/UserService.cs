using ApiUsers.Data.Dtos.User;
using ApiUsers.Data.Requets;
using ApiUsers.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ApiUsers.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public UserService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result CreateUser(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            IdentityUser<int> userI = _mapper.Map<IdentityUser<int>>(user);
            var resultIdentity = _userManager.CreateAsync(userI, userDto.Password).Result; 
            _userManager.AddToRoleAsync(userI, "regular");

            if (resultIdentity.Succeeded) 
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(userI).Result;
                var encodeCode = HttpUtility.UrlEncode(code);
                _emailService.sendEmail(new[] {userI.Email}, "Link de ativação", userI.Id, encodeCode);
                return Result.Ok().WithSuccess(code);
            };
            return Result.Fail("Houve um erro na criação do usuario!");
        }

        public Result ConfirmationAccount(AccountConfirmationRequest request)
        {
            var userI = _userManager.Users.FirstOrDefault(u => u.Id == request.AccountId);
            if (userI == null)
            {
                return Result.Fail($"No account found with id: {request.AccountId}");
            }
            var confirmation = _userManager.ConfirmEmailAsync(userI, request.Code).Result;
            if(confirmation.Succeeded) return Result.Ok().WithSuccess(confirmation.ToString());
            return Result.Fail("The confirmation code is invalid!");
        }
    }
}
