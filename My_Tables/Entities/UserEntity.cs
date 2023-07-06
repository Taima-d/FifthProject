using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class UserEntity : IdentityUser
    {
        public Type_Of UserType { get; set; }
        //one to one relation
        public HotelEntity HotelEntity { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
     

    }

    public enum Type_Of
    {
       Hotel ,
       Customer
    }
}

