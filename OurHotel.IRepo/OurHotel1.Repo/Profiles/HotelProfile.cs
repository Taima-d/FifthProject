using AutoMapper;
using My_Tables.Entities;
using OurHotels.Dto.Hotel;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel1.Repo.Profiles
{
     public class HotelProfile : Profile
    {

        public HotelProfile()
        {
            CreateMap<HotelEntity, HotelDto>().ReverseMap();
            //AddHotelDto
            CreateMap<AddHotelFromAdminDto, HotelEntity>();
            CreateMap<HotelEntity,AddHotelDto>().ReverseMap();
            CreateMap<RoomEntity, RoomDto>().ReverseMap();
            CreateMap<RoomImageEntity, RoomImageDto>().ReverseMap();
        }
    }
}
