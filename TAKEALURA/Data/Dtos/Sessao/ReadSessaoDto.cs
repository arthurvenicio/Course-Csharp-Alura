using System;
using System.ComponentModel.DataAnnotations;

namespace TAKEALURA.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public virtual Models.Cinema Cinema { get; set; }
        public virtual Models.Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
