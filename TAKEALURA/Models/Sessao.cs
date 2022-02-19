using System;
using System.ComponentModel.DataAnnotations;

namespace TAKEALURA.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        [Required(ErrorMessage = "É necessario preencher o campo do Id do Filme!")]
        public int FilmeId { get; set; }
        [Required(ErrorMessage = "É necessario preencher o campo do Id do Cinema!")]
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }

    }
}
