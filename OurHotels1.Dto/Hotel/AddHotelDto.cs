using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
    public class AddHotelDto
    {
        [Key]
        public int HotelEntityId { get; set; }

        [Required, MaxLength(50)]
       
        public string HotelName { get; set; }

        [Required, MaxLength(50)]
        public string ManagerName { get; set; }

        [MaxLength(200),Required]
        public string HotelAddress { get; set; }

        [Required]
        public string City { get; set; }
        public State State { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(7), MinLength(7)]
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone1 { get; set; }

        [MaxLength(7), MinLength(7)]
       // [RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone2 { get; set; }


        [Required]
      //  [MaxLength(9), MinLength(9)]
      ///^9\d{7}$/
    

        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string ManegerPhone { get; set; }


        [Required]
        public int numOfStars { get; set; }

       // [ForeignKey(Users)]
        public string UserEntityId { get; set; }
       // public UserEntity UserEntity { get; set; }

        [Display(Name = "Hotel Picture")]
        public byte[] HotelPicture { get; set; }
        //[Required]
        [Display(Name = "Identity Certifcate")]
        public byte[] IdentityCertifcate { get; set; }

    }
    public enum Cities
    {
        [Display(Name = " ")] 
        value1, 
        Damascus,
        Damascus_Countryside,
        Aleppo,
        AlHasakah,
        Homs,
        Hama,
        Daraa,
        Latakia,
        Tartus,
        Idlib,
        AlRaqqah,
        Alqunaytirah,
        DayralZawr,
        AlSuwayda
    }
    public enum State
    {
        pending,
        confirmed,
        canceled

    }
}
