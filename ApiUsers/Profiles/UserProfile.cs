using ApiUsers.Data.Dtos.User;
using ApiUsers.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiUsers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
        }
    }
}
