using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class HotelEntity
    {
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HotelEntityId { get; set; }

        [Required, MaxLength(50)]
        public string HotelName { get; set; }

        public string  ManagerName { get; set; }

        [MaxLength(200)]
        public string HotelAddress { get; set; }
        public City City { get; set; }
        public State State { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(9), MinLength(9)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone1 { get; set; }

        [MaxLength(9), MinLength(9)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone2 { get; set; }


        [Required]
        [MaxLength(9), MinLength(9)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
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
        public UserEntity UserEntity { get; set; }
        //one to many
        public virtual ICollection<RoomEntity> RoomEntities { get; set; }
        public virtual ICollection<Hotel_ExtraEntity> Hotel_ExtraEntities { get; set; }

     

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
    public enum State
    {
        pending,
        confirmed,
        canceled

    }
}
