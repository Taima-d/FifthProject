﻿using System.ComponentModel.DataAnnotations;

namespace OurHotels.Dto.User
{
    public class LoginUserDto
    {
        [Required]
        [Display(Name = "Email or Username")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string type_Of { get; set; }
    }
}
