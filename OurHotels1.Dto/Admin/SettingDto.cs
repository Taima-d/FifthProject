using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Admin
{
   public class SettingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] logo{ get; set; }

    }
}
