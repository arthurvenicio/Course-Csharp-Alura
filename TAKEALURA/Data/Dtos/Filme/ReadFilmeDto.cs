﻿using System;
using System.ComponentModel.DataAnnotations;
using TAKEALURA.Data.Dtos.Base;

namespace TAKEALURA.Data.Dtos.Filme
{
    public class ReadFilmeDto : ReadDtoBase
    {
        [Key] [Required] public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é requerido!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo diretor é requerido!")]
        public string Director { get; set; }

        [Required(ErrorMessage = "O campo Genero é requerido!")]
        public string Genre { get; set; }

        [Required, Range(1, 600, ErrorMessage = "A duração não pode passar de 600 minutos.")]
        public int Duration { get; set; }
    }
}