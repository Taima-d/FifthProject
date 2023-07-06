using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
    public class EditHotelDto
    {
        [Key]
        public int HotelEntityId { get; set; }

        [MaxLength(50)]
        public string ManagerName { get; set; }

        [MaxLength(200)]
        public string HotelAddress { get; set; }

        
        public Cities City{ get; set; }
        public State State { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(9), MinLength(7)]
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone1 { get; set; }

        [MaxLength(9), MinLength(7)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone2 { get; set; }
        //  [MaxLength(9), MinLength(9)]
        ///^9\d{7}$/
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string ManegerPhone { get; set; }
        public int numOfStars { get; set; }

        // [ForeignKey(Users)]
        // public string UserEntityId { get; set; }
        // public UserEntity UserEntity { get; set; }

        [Display(Name = "Hotel Picture")]
        public byte[] HotelPicture { get; set; }
        //[Required]
        //  [Display(Name = "Identity Certifcate")]
        //  public byte[] IdentityCertifcate { get; set; }

    }
   
   



}
enum Cities1
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
