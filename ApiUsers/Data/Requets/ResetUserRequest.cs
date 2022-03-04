using System.ComponentModel.DataAnnotations;

namespace ApiUsers.Data.Requets
{
    public class ResetUserRequest
    {
        [Required] public string Email { get; set; }
        [Required][DataType(DataType.Password)] public string Password { get; set; }
        [Required] [Compare("Password")]public string RePassword { get; set; }
        [Required] public string Token { get; set; }
    }
}