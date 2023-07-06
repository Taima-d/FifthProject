using OurHotels.Dto.Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Room
{
   public class RoomImageDto
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        [ForeignKey("Rooms")]
        public int RoomEntityId { get; set; }
        public RoomDto Room { get; set; }

    }
}
