using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class CustomerEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CustomerEntityId { get; set; }

        [Required, ForeignKey("Users")]
        public string UserEntityId { get; set; }


        [Required, MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [Range(10, 20)]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Entered Number Should be Intigeer")]
        public int phoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public byte[] Identity_Certificate { get; set; }
        public Gender gender { get; set; }

        //one to one relation
        public UserEntity UserEntity { get; set; }

       
        //one to many relation
        public virtual ICollection<BillEntity> BillEntities { get; set; }
        
    }
    public enum Gender
    {
        Male,
        Female
    }
   
}
