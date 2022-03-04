using System.ComponentModel.DataAnnotations;

namespace ApiUsers.Data.Requets
{
    public class RequestResetUser
    {
        [Required(ErrorMessage = "Email can't empty!")]
        public string Email { get; set; }
    }
}