using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class RoomEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoomEntityId { get; set; }

        [Required]
        [ForeignKey("Hotels")]
        public int HotelEntityId { get; set; }

        [Range(1,6)]
        public int? numOfBeds { get; set; }
        public bool  spouseBeds { get; set; }

        // public int ExtraBedLimit { get; set; }

        [Range(4,7)]
        public int phone { get; set; }

        public int RoomNum { get; set; }

        [Display(Name = "Room Picture")]
        public byte[] RoomPicture { get; set; }

        // to reach price from any date
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string RoomSizeW { get; set; }// width
        public string RoomSizeH { get; set; }//height
        public string RoomDirection1 { get; set; }// N S
        public string RoomDirection2 { get; set; }// E W
        public bool suite { get; set; }
        public int? numOfRoom { get; set; }

        public string floor { get; set; }

        [Required]
        public double Price { get; set; }

        //one to many relation
        public virtual ICollection<BookingEntity> BookingEntities { get; set; }
        //one to many 
        public ICollection<RoomImageEntity> Images { get; set; }
        public HotelEntity HotelEntity  { get; set; }
       
    }
}
