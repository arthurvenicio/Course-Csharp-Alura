using System;

namespace ApiCinema.Models.Erros
{
    public class CreateCinemaError
    {
        public bool Sucess { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime consultAt { get; set; }
    }
}
