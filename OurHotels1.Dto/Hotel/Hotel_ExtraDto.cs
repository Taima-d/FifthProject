using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
  public  class Hotel_ExtraDto
    {
        [Key]
        public int Hotel_ExtraEntityId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Hotels")]
        public int HotelEntityId { get; set; }

        [Required]
        [ForeignKey("Extra_Services")]
        public Guid Extra_ServiceEntityId { get; set; }


        public double Price { get; set; }
        public string Description { get ;set ;}

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        //one to many relation
      //  public virtual ICollection<Booking_ExtraEntity> Booking_ExtraEntities { get; set; }
       // public virtual HotelEntity HotelEntity { get; set; }
     // public virtual Extra_ServicesDto  Extra_ServicesDto { get; set; }

    }
}

