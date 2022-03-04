
using ApiUsers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiUsers.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> identityUser, string role)
        {
            Claim[] rights = new Claim[] 
            {
                new Claim("username", identityUser.UserName),
                new Claim("id", identityUser.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ua12sad484dafas92fsa33dsfa09fgasdh87uasfa194gagj02fabas23afs"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(claims: rights, signingCredentials: credentials, expires: DateTime.UtcNow.AddHours(1));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }
    }
}
