﻿using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class User
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
