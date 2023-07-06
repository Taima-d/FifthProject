using AutoMapper;
using My_Tables.Entities;
using MyDbProject;
using OurHotel.IRepo;
using OurHotel1.Repo.My_Ex;
using OurHotels.Dto.Hotel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using My_Tables.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace OurHotel1.Repo
{
    public class HotelRepo : IHotelRepo
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public HotelRepo(ApplicationDbContext applicationDbContext, IMapper mapper , UserManager<UserEntity> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }
        public void AddHotel(AddHotelDto addHotelDto, byte[] l , byte[]l1)
        {
         var city = addHotelDto.City;
         //   var HotelNames = _applicationDbContext.Hotels.Where(s => s.HotelName.ToLower() == addHotelDto.HotelName.ToLower() && s.City.ToString() == city).Any();
            //if (HotelNames)
            //    {
            //    //ModelState.AddModelError(string.Empty, "This hotel name is exist");
            //    throw new NameEx();
            //    }
                 var result = _mapper.Map<HotelEntity>(addHotelDto);
                 result.IdentityCertifcate = l;
                 result.HotelPicture = l1;
                _applicationDbContext.Add(result);
                _applicationDbContext.SaveChanges();
            
    }

        public void UpdateHotel(HotelDto Updatedto)
        {
            var res = _mapper.Map<HotelEntity>(Updatedto);
            _applicationDbContext.Hotels.Update(res);
            _applicationDbContext.SaveChanges();
        }
        public void EditeHotel(int hotelId, EditHotelDto Updatedto)
        {
            var res = _applicationDbContext.Hotels.FirstOrDefault(x => x.HotelEntityId == hotelId);
            if (res != null)
            {
                if (!string.IsNullOrEmpty(Updatedto.ManagerName))
                {
                    res.ManagerName = Updatedto.ManagerName;
                }
                if (!string.IsNullOrEmpty(Updatedto.ManegerPhone))
                {
                    res.ManegerPhone = Updatedto.ManegerPhone;
                }
                if (!string.IsNullOrEmpty(Updatedto.Phone1))
                {
                    res.Phone1 = Updatedto.Phone1;
                }
                if (!string.IsNullOrEmpty(Updatedto.Phone2))
                {
                    res.Phone2 = Updatedto.Phone2;
                }
                if (!string.IsNullOrEmpty(Updatedto.HotelAddress))
                {
                    res.HotelAddress = Updatedto.HotelAddress;
                }
                if (!string.IsNullOrEmpty(Updatedto.Description))
                {
                    res.Description = Updatedto.Description;
                }
               
                
                    res.numOfStars = Updatedto.numOfStars;
                res.HotelPicture = Updatedto.HotelPicture;
              
                    res.City = (My_Tables.Entities.City)Updatedto.City;

                
                //if (!string.IsNullOrEmpty(Convert.ToBase64String(Updatedto.HotelPicture)))
                //{
                //    res.HotelPicture = Updatedto.HotelPicture;
                //}
            }
            _applicationDbContext.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            var result = _applicationDbContext.Hotels.FirstOrDefault(x => x.HotelEntityId == id);
            if (result != null)
            {
                _applicationDbContext.Hotels.Remove(result);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                // throw new NotFoundException();
            }


        }
        public HotelDto GetHotelById(int id)
        {
            var res = _applicationDbContext.Hotels.FirstOrDefault(x => x.HotelEntityId == id);
            if (res == null)
            {
                throw new();
            }
            else
            {
                var result = _mapper.Map<HotelDto>(res);
                return result;

            }
        }
        public int GetHotelCount()
        {
            return _applicationDbContext.Hotels.Count();
        }
        public List<HotelDto> GetAllHotel()
        {
            List<HotelDto> Hotels = new List<HotelDto>();
            var result = _applicationDbContext.Hotels.ToList();
            foreach (var item in result)
            {
                Hotels.Add(_mapper.Map<HotelDto>(item));
            }
            return Hotels;



        }
        public void AddHotelFromAdmin(AddHotelFromAdminDto addDto, string UserId)
        {
             addDto.UserEntityId = UserId;
             var result = _mapper.Map<HotelEntity>(addDto);
            _applicationDbContext.Hotels.Add(result);
            _applicationDbContext.SaveChanges();
        }
        public List< RoomDto> GetAllRooms (int hotelId)
        {

            List<RoomDto> rooms = new List<RoomDto>();
            var result = _applicationDbContext.RoomEntities.Where(s=>s.HotelEntityId==hotelId).ToList();
            var images = new List<RoomImageEntity>();
            foreach (var item in result)
            {
                images = _applicationDbContext.RoomImageEntities.Where(x=>x.RoomEntityId==item.RoomEntityId).ToList();
                //foreach( var im in images)
                //{
                //    var url = im.Url;
                //    var imageAfterCrop = url.Split("wwwroot").ElementAt(1);

                //}
              

                item.Images = images;
                
                rooms.Add(_mapper.Map<RoomDto>(item));

            }
            return rooms;


        }
        public  HotelDto HotelProfileSettingInfo(string id)
        {
            var HotelId = _applicationDbContext.Users
                .Where(y => y.Id == id)
                .Select(y => y.HotelEntity.HotelEntityId)
                .FirstOrDefault();

            var HotelProfileSettingInfo = _applicationDbContext.Hotels
                 .Where(r => r.HotelEntityId == HotelId)
                 .Select(r => new HotelDto
                 {
                     HotelName = r.HotelName,
                     ManagerName = r.ManagerName,
                     HotelAddress = r.HotelAddress,
                   //  HotelPicture = r.HotelPicture,
                     ManegerPhone = r.ManegerPhone,
                     numOfStars = r.numOfStars,
                     Phone1 = r.Phone1,
                     Phone2 = r.Phone2,
                     //  IdentityCertifcate = r.IdentityCertifcate,
                     City = (Cities)r.City,
                   
            // State=r.State

        }).FirstOrDefault();

            return HotelProfileSettingInfo;
        }



        public void AddServices(string id, Hotel_ExtraDto hotel_ExtraDto)
        {
            var hotelId = _applicationDbContext.Users
                .Where(user => user.Id == id)
                .Select(user => user.HotelEntity.HotelEntityId)
                .FirstOrDefault();

            if (hotelId != 0)
            {
                var extraServicesEntity = new Extra_ServicesEntity
                {
                    Extra_ServicesName = hotel_ExtraDto.Name,
                    Description = hotel_ExtraDto.Description,
                    Hotel_ExtraEntities = new List<Hotel_ExtraEntity>
            {
                new Hotel_ExtraEntity
                {
                    HotelEntityId = hotelId,
                    Price = hotel_ExtraDto.Price
                }
                // Add more Hotel_ExtraEntity instances if needed
            }
                };

                _applicationDbContext.Extra_Services.Add(extraServicesEntity);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                // Handle the case where the hotelId is not found for the given user
                // You can throw an exception, log an error, or handle it according to your requirements
                throw new Exception("HotelId not found for the given user.");
            }
        }

    }
}
