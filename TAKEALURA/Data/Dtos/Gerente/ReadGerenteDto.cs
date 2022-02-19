using System.ComponentModel.DataAnnotations;
using TAKEALURA.Models;
using TAKEALURA.Data.Dtos.Base;
using System.Collections.Generic;

namespace TAKEALURA.Data.Dtos.Gerente
{
    public class ReadGerenteDto : ReadDtoBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome não pode ficar vazio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo documento não pode ficar vazio!")]
        public string Document { get; set; }
        public object Cinemas { get; set; }
    }
}