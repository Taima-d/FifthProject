using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class BookingEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookingEntityId { get; set; }

        [Required]
        [ForeignKey("Rooms")]
        public int RoomEntityId { get; set; }

        [Required]
        [ForeignKey("Bills")]
        public int BillEntityId { get; set; }

        public double Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime checkIn { get; set; }

        [DataType(DataType.Date)]
        public DateTime checkOut { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [MaxLength(100)]
        public string Reviews { get; set; }

        [Range(0,7)]
        public int Rate { get; set; }

        //one to many relation
        public virtual ICollection<Booking_ExtraEntity> Booking_ExtraEntities { get; set; }
        public virtual RoomEntity  RoomEntity { get; set; }
        public virtual BillEntity  BillEntity { get; set; }

    }
}
