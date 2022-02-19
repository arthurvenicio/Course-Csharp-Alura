using System.ComponentModel.DataAnnotations;

namespace TAKEALURA.Data.Dtos.Gerente
{
    public class UpdateGerenteDto
    {
        [Required(ErrorMessage = "O campo nome não pode ficar vazio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo documento não pode ficar vazio!")]
        public string Document { get; set; }
    }
}