using AutoMapper;
using My_Tables.Entities;
using OurHotels.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel1.Repo.Profiles
{
   public class WebsiteProfile : Profile
    {
        public WebsiteProfile()
        {
            CreateMap<WebsiteEntity, SettingDto>().ReverseMap();
        }
    }
}
