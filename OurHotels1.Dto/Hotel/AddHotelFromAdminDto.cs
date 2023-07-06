using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
    public class AddHotelFromAdminDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HotelEntityId { get; set;  }
        //[Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "PasswordRequiresNonAlphanumeric,PasswordRequiresLower,PasswordRequiresUpper")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[Required, MaxLength(50)]
        public string HotelName { get; set; }

        public string ManagerName { get; set; }

        [MaxLength(200)]
        public string HotelAddress { get; set; }
        public City City { get; set; }
        public State State { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        //[Required]
        [MinLength(4), MaxLength(50)]
        
        public string Phone1 { get; set; }

        [MinLength(4), MaxLength(50)]
       
        public string Phone2 { get; set; }


        //[Required]
        [MinLength(4), MaxLength(50)]
        
        public string ManegerPhone { get; set; }


        [Range(1, 7)]
        public int numOfStars { get; set; }




        [ForeignKey("Users")]
        public string UserEntityId { get; set; }

        // photo 
        [Display(Name = "Hotel Picture")]
        public byte[] HotelPicture { get; set; }
        public byte[] IdentityCertifcate { get; set; }
        

        //one to one relation



    }
    public enum City
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
    //public enum State
    //{
    //    pending,
    //    confirmed,
    //    canceled

    //}
}


