﻿using System.ComponentModel.DataAnnotations;

namespace ApiUsers.Data.Requets
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}