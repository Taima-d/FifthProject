using AutoMapper;
using My_Tables.Entities;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel1.Repo.Profiles
{
  public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomEntity, AddRoomDto>().ReverseMap();
            CreateMap<RoomEntity, AddSuitDto>().ReverseMap();
        }
    }
}
