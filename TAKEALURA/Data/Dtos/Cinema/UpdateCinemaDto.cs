using System.ComponentModel.DataAnnotations;

namespace TAKEALURA.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome não pode ficar vazio!")]
        public string Name { get; set; }
        [Required]
        public int EnderecoId { get; set; }
    }
}