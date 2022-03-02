using System.ComponentModel.DataAnnotations;

namespace ApiUsers.Data.Requets
{
    public class AccountConfirmationRequest
    {
        [Required(ErrorMessage ="You must be enter the AccountId!")]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "You must be enter the confirmation code!")]
        public string Code { get; set; }
    }
}
