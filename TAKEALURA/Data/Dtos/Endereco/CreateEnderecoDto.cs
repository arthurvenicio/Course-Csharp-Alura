using System.ComponentModel.DataAnnotations;

namespace TAKEALURA.Data.Dtos.Endereco
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage = "O campo lagrodouro não pode ficar vazio!")]
        public string Lagrodouro { get; set; }
        [Required(ErrorMessage = "O campo Cep não pode ficar vazio!")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O campo Numero não pode ficar vazio!")]
        public int Numero { get; set; } 
    }
}