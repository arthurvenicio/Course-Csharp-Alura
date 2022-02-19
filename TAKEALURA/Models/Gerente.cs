using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TAKEALURA.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome não pode ficar vazio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo documento não pode ficar vazio!")]
        public string Document { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }

    }
}