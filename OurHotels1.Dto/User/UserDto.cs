using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.User
{
    public class UserDto
    {
        [Key]
        public int UserEntityId { get; set; }

    }
}
