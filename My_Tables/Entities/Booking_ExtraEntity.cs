using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class Booking_ExtraEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Booking_ExtraEntityId { get; set; }

        [Required]
        [ForeignKey("Bookings")]
        public int BookingEntityId { get; set; }

        [Required]
        [ForeignKey("Hotel_Extras")]
        public int Hotel_ExtraEntityId { get; set; }

        public double Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        // one to many 
        public virtual Hotel_ExtraEntity Hotel_ExtraEntity { get; set; }
        public virtual BookingEntity BookingEntity { get; set; }
    }
}
