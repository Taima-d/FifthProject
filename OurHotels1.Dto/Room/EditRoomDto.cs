using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Room
{
    public class EditRoomDto
    {
        
       public int RoomId { get; set; }
        public int HotelEntityId { get; set; }

        [Range(1, 6)]
        public int? numOfBeds { get; set; }

        // public int ExtraBedLimit { get; set; }

        
        public int? phone { get; set; }
       
        public int? RoomNum { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string RoomSizeW { get; set; }// width
        public string RoomSizeH { get; set; }//height
        public string RoomDirection1 { get; set; }// N S
        public string RoomDirection2 { get; set; }// E W
        public bool? suite { get; set; }
        public int? numOfRoom { get; set; }
      
        public double? Price { get; set; }
        public string Floor { get; set; }
        public List<string> ImageUrls { get; set; }
        public AddRoomImageDto AddRoomImageDto { get; set; }
    }
}
