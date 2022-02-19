using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TAKEALURA.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é requerido!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo diretor é requerido!")]
        public string Director { get; set; }
        [Required(ErrorMessage = "O campo Genero é requerido!")]
        public string Genre { get; set; }
        [Required, Range(1, 600, ErrorMessage = "A duração não pode passar de 600 minutos.")]
        public int Duration { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}