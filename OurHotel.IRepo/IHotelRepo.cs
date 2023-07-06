using OurHotels.Dto.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.IRepo
{
   public interface IHotelRepo
    {
        public void AddHotel(AddHotelDto addHotelDto, byte[] l, byte[] l1);
        public void AddHotelFromAdmin(AddHotelFromAdminDto addDto ,string UserId);
        public void UpdateHotel(HotelDto Updatedto);
        public void DeleteHotel(int id);
        public HotelDto GetHotelById(int id);
        public int GetHotelCount();
        public List<HotelDto> GetAllHotel();
        public HotelDto HotelProfileSettingInfo(string id);
        public void EditeHotel(int hotelId, EditHotelDto Updatedto);
        public List<RoomDto> GetAllRooms(int hotelId);
      public  void AddServices(string id, Hotel_ExtraDto hotel_ExtraDto);
    }
}
