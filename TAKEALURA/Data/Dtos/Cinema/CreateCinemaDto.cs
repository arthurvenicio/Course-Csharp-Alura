using System.ComponentModel.DataAnnotations;

namespace TAKEALURA.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome não pode ficar vazio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Id do endereço não pode ficar vazio!")]
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "O campo Id do gerente não pode ficar vazio!")]
        public int GerenteId { get; set; }
    }
}