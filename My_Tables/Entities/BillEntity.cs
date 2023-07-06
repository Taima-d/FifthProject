using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class BillEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BillEntityId { get; set; }

        [Required]
        [ForeignKey("Customers")]
        public int CustomerEntityId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string pdfFile { get; set; }
        
        //one to many relation
        public virtual ICollection<BookingEntity> BookingEntities { get; set; }
        public virtual CustomerEntity  CustomerEntity { get; set; }
    }
}
