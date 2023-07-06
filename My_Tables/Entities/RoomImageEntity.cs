using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Tables.Entities
{
   public class RoomImageEntity
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        [ForeignKey("Rooms")]
        public int RoomEntityId { get; set; }
        public RoomEntity Room { get; set; }
    }
}
