using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class Extra_ServicesEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Extra_ServicesEntityId { get; set; }

        [Required, MaxLength(50)]
        public string Extra_ServicesName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }


        [Display(Name = "Extra Services Picture")]
        public byte[] Extra_ServicesPicture { get; set; }

        //one to many relation
        public virtual ICollection<Hotel_ExtraEntity> Hotel_ExtraEntities { get; set; }
    }
}
