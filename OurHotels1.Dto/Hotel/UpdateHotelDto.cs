using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
   public class UpdateHotelDto
    {
        public int HotelEntityId { get; set; }
        public string HotelName { get; set; }
        public string ManagerName { get; set; }
        public string HotelAddress { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public int numOfStars { get; set; }
        public string ManegerPhone { get; set; }
        public string Phone1 { get; set; }
        public byte[] HotelPicture { get; set; }
        public byte[] IdentityCertifcate { get; set; }

    }
}
