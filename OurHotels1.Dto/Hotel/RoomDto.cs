using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
    public class RoomDto
    {
            [Key]
            public int RoomEntityId { get; set; }
            //[Required]
            //[ForeignKey("Hotels")]
            //public int HotelEntityId { get; set; }

            //[Range(1, 6), Required]
            public int numOfBeds { get; set; }

            // public int ExtraBedLimit { get; set; }

            [Required]
            public int phone { get; set; }
            [Display(Name = "Hotel Picture")]
           public byte[] HotelPicture { get; set; }

        [Required]
        public int? RoomNum { get; set; }

        //[Display(Name = "Room Picture")]
        //public byte[] RoomPicture { get; set; }
        // to reach price from any date
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string RoomSizeW { get; set; }// width
        public string RoomSizeH { get; set; }//height
        public string RoomDirection1 { get; set; }// N S
            public string RoomDirection2 { get; set; }// E W
            public bool? suite { get; set; }
            public int? numOfRoom { get; set; }
            [Required]
            public double? Price { get; set; }
        public string Floor { get; set; }
        // public List<string> ImageUrls { get; set; }
        public ICollection<RoomImageDto> Images { get; set; }

    }
}
