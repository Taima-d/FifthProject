using AutoMapper;
using My_Tables.Entities;
using MyDbProject;
using OurHotel.IRepo;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using OurHotels.Dto.Hotel;

namespace OurHotel1.Repo
{
    public class RoomRepo : IRoomRepo
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        //private readonly HttpContext _httpContext;
        public RoomRepo(ApplicationDbContext applicationDbContext, IMapper mapper, UserManager<UserEntity> userManager /*, IHttpContextAccessor httpContextAccessor*/)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _userManager = userManager;
          //  _httpContext = httpContextAccessor.HttpContext;
        }
        public async Task AddRoom(AddRoomDto addRoomDto ,string userId)
        {
          //  var userId = _userManager.GetUserId(_httpContext.User);
         //   var userId = _userManager.GetUserId(ClaimsPrincipal.Current);
         //   var userId = user.Id;
           var hotelId = _applicationDbContext.Hotels
          .Where(h => h.UserEntityId == userId)
               .Select(h => h.HotelEntityId)
                .FirstOrDefault();
          
            if(hotelId != null)
            {
                addRoomDto.HotelEntityId = hotelId;
                addRoomDto.suite = false;
                var result = _mapper.Map<RoomEntity>(addRoomDto);
                var roomModel = await _applicationDbContext.RoomEntities.AddAsync(result);
                await _applicationDbContext.SaveChangesAsync();
                await _applicationDbContext.RoomImageEntities.AddRangeAsync(addRoomDto.ImageUrls.Select(x => new RoomImageEntity
                {
                    Url = x,
                    RoomEntityId = roomModel.Entity.RoomEntityId  
                }).ToList());
                await _applicationDbContext.SaveChangesAsync();
            }

            //var imageAfterCrop = url.Split("wwwroot").ElementAt(1);
        }
        public void DeleteRoom(int roomId)
        {
            var room = _applicationDbContext.RoomEntities.Find(roomId);
            var roomIamges = _applicationDbContext.RoomImageEntities.Where(s => s.RoomEntityId == roomId).ToList();
            if (room != null)
            {
                foreach( var roomImage in roomIamges)
                {
                    _applicationDbContext.RoomImageEntities.Remove(roomImage);
                }
                _applicationDbContext.RoomEntities.Remove(room);
                _applicationDbContext.SaveChanges();
            }
        }
        public void EditRoomD(int RoomId , EditRoomDto editRoom)
        {
            var res = _applicationDbContext.RoomEntities.Where(s => s.RoomEntityId == RoomId).FirstOrDefault();
            var imageres = _applicationDbContext.RoomImageEntities.Where(l => l.RoomEntityId == RoomId).ToList();
            if(res != null)
            {
                if (editRoom.numOfBeds !=null )
                {
                    res.numOfBeds = (int)editRoom.numOfBeds;

                }
                     if(editRoom.phone != null)
                {
                    res.phone = (int)editRoom.phone;
                }
                if (editRoom.Price !=null)
                {
                    res.Price = (double)editRoom.Price;
                }
                if (!string.IsNullOrEmpty(editRoom.RoomDirection1))
                {
                    res.RoomDirection1 = editRoom.RoomDirection1;
                }
                if (!string.IsNullOrEmpty(editRoom.RoomDirection2))
                {
                    res.RoomDirection2 = editRoom.RoomDirection2;
                }
                  if (!string.IsNullOrEmpty(editRoom.RoomSizeH))
                {
                    res.RoomDirection2 = editRoom.RoomSizeH;
                }
                if (!string.IsNullOrEmpty(editRoom.RoomSizeW))
                {
                    res.RoomSizeW = editRoom.RoomSizeW;
                }
                //foreach(var image in editRoom.ImageUrls)
                //{

                //}
                
            }


        }
        public void AddSuit(AddSuitDto addSuitDto, string userId)
        {
            //var userId = _userManager.GetUserId(user);
            //  var userId = _userManager.GetUserId(_httpContext.User);
            //   var userId = _userManager.GetUserId(ClaimsPrincipal.Current);
            //   var userId = user.Id;
            var hotelId = _applicationDbContext.Hotels
            .Where(h => h.UserEntityId == userId)
            .Select(h => h.HotelEntityId)
            .FirstOrDefault();
            addSuitDto.HotelEntityId = hotelId;
            addSuitDto.suite = true;
            // var userId = User.Identity.GetUserId();
            //  var hotelId = _applicationDbContext.Hotels.Where(s=>s.UserEntityId== this.User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(e=>e.HotelEntityId).FirstOrDefault();
            var result = _mapper.Map<RoomEntity>(addSuitDto);
            
            _applicationDbContext.Add(result);
            _applicationDbContext.SaveChanges();


            

        }
        public RoomDto GetRoombyId(int RoomId)
        {
            var room = _applicationDbContext.RoomEntities.Where(s => s.RoomEntityId == RoomId).
             FirstOrDefault();
            if( room == null)
            {

                throw new();
            }
            else
            {
                var images = _applicationDbContext.RoomImageEntities.Where(s => s.RoomEntityId == RoomId).ToList();
                room.Images = images;
                var res= _mapper.Map<RoomDto>(room);
                
                return res;

            }

        }
    }
}
