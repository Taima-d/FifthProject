using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Customer
{
   public class UpdateCustomerDto
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public int CustomerEntityId { get; set; }

        //[Required, ForeignKey("Users")]
        public string UserEntityId { get; set; }


        [Required, MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [MinLength(10), MaxLength(20)]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Entered Number Should be Intigeer")]
        public string phoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public byte[] Identity_Certificate { get; set; }
        public Gender gender { get; set; }


    }
}
