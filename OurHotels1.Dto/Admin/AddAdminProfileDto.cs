using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Admin
{
  public  class AddAdminProfileDto
    {
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        public string FirstName { get; set; }

        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        public string LastName { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Only numbers are allowed.")]
        public string Mobiel { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public  string Password { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public byte[] AdminPhoto { get; set; }
    }
}
