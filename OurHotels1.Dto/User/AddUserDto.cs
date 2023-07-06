using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.User
{
  public  class AddUserDto
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PasswordRequiresNonAlphanumeric,PasswordRequiresLower,PasswordRequiresUpper")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid number")]
        public int Mobile { get; set; }
    }
    public enum Type_Of
    {
        Hotel,
        Customer
    }
}
