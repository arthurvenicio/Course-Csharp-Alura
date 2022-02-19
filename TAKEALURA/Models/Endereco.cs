using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TAKEALURA.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo lagrodouro não pode ficar vazio!")]
        public string Lagrodouro { get; set; }
        [Required(ErrorMessage = "O campo Cep não pode ficar vazio!")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O campo Numero não pode ficar vazio!")]
        public int Numero { get; set; } 
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}