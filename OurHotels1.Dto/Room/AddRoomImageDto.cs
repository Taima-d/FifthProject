using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Room
{
    public class AddRoomImageDto
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }

        [ForeignKey("Rooms")]
        public int RoomEntityId { get; set; }
      //  public R Room { get; set; }
    }
}
