using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Admin
{
   public class ProfileAdminDto
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobiel { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public  string Password { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
