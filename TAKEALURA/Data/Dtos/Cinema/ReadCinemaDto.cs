using System;
using System.ComponentModel.DataAnnotations;
using TAKEALURA.Data.Dtos.Base;
using TAKEALURA.Models;

namespace TAKEALURA.Data.Dtos.Cinema
{
    public class ReadCinemaDto : ReadDtoBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome não pode ficar vazio!")]
        public string Name { get; set; }
        [Required]
        public Models.Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}