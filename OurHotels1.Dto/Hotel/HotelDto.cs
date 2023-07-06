using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
   public class HotelDto
    {

        public int HotelEntityId { get; set; }
        public string HotelName { get; set; }
        public string ManagerName { get; set; }
        public string HotelAddress { get; set; }
      public Cities City { get; set; }
       public State State { get; set; }
        public int numOfStars { get; set; }
        public string ManegerPhone { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Description { get; set; }
         public byte[] HotelPicture { get; set; }
        //   public byte[] IdentityCertifcate { get; set; }
        //  public UserEntity UserEntity { get; set; }
        //one to many
        // public virtual ICollection<RoomEntity> RoomEntities { get; set; }
        // public virtual ICollection<Hotel_ExtraEntity> Hotel_ExtraEntities { get; set; }
    }
   
    
}
enum Cities
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