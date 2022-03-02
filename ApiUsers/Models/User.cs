using System.ComponentModel.DataAnnotations;

namespace ApiUsers.Models
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário preencher o campo usuario!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "É necessário preencher o campo email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "É necessário preencher o campo password!")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="As senhas não combinam!")]
        public string RePassword { get; set; }

    }
}
