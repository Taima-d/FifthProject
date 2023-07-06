using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
    public class AdminEntity
    {
      [Key]
      public  int Id { get; set; }
      public  string FirstName { get; set; }
      public  string LastName { get; set; }
      public  string Mobiel { get; set; }
      public  DateTime DateOfBirth { get; set; }
      //public  string Password { get; set; }
      public  string City { get; set; }
      public  string Address { get; set; }
      public  byte[] AdminPhoto { get; set; }
         

    }
}
