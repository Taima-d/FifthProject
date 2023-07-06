using OurHotels.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.IRepo
{
   public interface IAdminRepo
    {
        public ProfileAdminDto GetAdminInfo();
        public void AddAdminProfile(AddAdminProfileDto addAdminProfileDto, byte[] l);
        public void AddAdminProfile(AddAdminProfileDto addAdminProfileDto);
     
    }
}
