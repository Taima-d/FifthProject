using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using My_Tables.Entities;
using MyDbProject;
using NToastNotify;
using OurHotel.IRepo;
using OurHotel1.Repo.My_Ex;
using OurHotels.Dto.Hotel;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Our_Hotels1.Controllers
{
    public class HotelController : Controller
    {
        public readonly ApplicationDbContext _applicationDbContext;
        private readonly IToastNotification _toastNotification;
        private readonly IHotelRepo _Ihotel;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ILogger<LogoutModel> _logger;

        public HotelController(ILogger<LogoutModel> logger, UserManager<UserEntity> userManager, IHotelRepo Ihotel, ApplicationDbContext applicationDbContext, IToastNotification toastNotification, IRoomRepo IRoom, SignInManager<UserEntity> signInManager)
        {
            this._Ihotel = Ihotel;
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
            _toastNotification = toastNotification;
            _userManager = userManager;
            _logger = logger;
        }
        public void LayoutInfo()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (Program.loginUserDto.type_Of == "Hotel")
                {
                    var UserEntityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Program.HotelName = _applicationDbContext.Hotels.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => n.HotelName).FirstOrDefault();
                    Program.HotelCity = _applicationDbContext.Hotels.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => n.City).FirstOrDefault().ToString();
                    Program.HotelPic =
                        _applicationDbContext.Hotels.Where(u => u.UserEntityId == UserEntityId)
                        .Select(u => u.HotelPicture).FirstOrDefault();
                }
                else if (Program.loginUserDto.type_Of == "Customer")
                {
                    var UserEntityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Program.CustomerName = _applicationDbContext.Customers.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => new { n.FirstName, n.LastName }).FirstOrDefault().ToString();
                }
            }
        }
        public async Task<IActionResult> HotelProfileSettingAsync(AddHotelDto addHotelDto)
        {
        //   var ss= _applicationDbContext.Hotels.Where()
            if (ModelState.IsValid)
            {
                try
                {
                    if (addHotelDto.City.ToString() == 0 + "")
                    {
                        ModelState.AddModelError("addHotelDto.City", "This field must be required ");
                        return View(addHotelDto);
                    }
                    if (addHotelDto.numOfStars.ToString() == " ")
                    {
                        ModelState.AddModelError("addHotelDto.numOfStars", "This field must be required ");
                        return View(addHotelDto);
                    }
                    if (Request.Form.Files.Count > 0)
                    {
                         var file = Request.Form.Files[0];
                         var file1 = Request.Form.Files[1];
                         var dataStream = new MemoryStream();

                         var datastream1 = new MemoryStream();
                         file.CopyTo(dataStream);

                         file1.CopyTo(datastream1);
                        var l = dataStream.ToArray();
                        var l1 = datastream1.ToArray();

                        _Ihotel.AddHotel(addHotelDto, l, l1);
                        // await _userManager.UpdateAsync(user);
                    }
                    _toastNotification.AddSuccessToastMessage("Your order is processing... ");
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignOutAsync();
                    _logger.LogInformation("User logged out.");
                    Program.loginUserDto.type_Of = null;
                    Program.AddUserDto.UserType = null;
                    return Redirect("/Identity/Account/Register");
                }
                catch (NameEx)
                {
                    ModelState.AddModelError("nameof(addHotelDto.HotelName)", "This hotel name is exist");
                    return View(addHotelDto);
                }
            }
            else
                return View(addHotelDto);
        }
        public async Task<IActionResult> RoomsList()
        {
            LayoutInfo();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var hotelId = _applicationDbContext.Hotels.Where(n => n.UserEntityId == x.Id)
                        .Select(n => n.HotelEntityId).FirstOrDefault();
            var res = _Ihotel.GetAllRooms(hotelId);

            //foreach (var im in res)
            //{
            //    foreach(var image in im.Images)
            //    {
            //        var url = image.Url;
            //        var imageAfterCrop = url.Split("wwwroot").ElementAt(1);
            //    }
            //}
            return View("AllRooms",res);
        }

        //[HttpGet]
        //[HttpPost]
        public async Task<IActionResult> EditHotelProfileSettingAsync(EditHotelDto editHotelDto)
        {

            LayoutInfo();
           
            var x = await _userManager.GetUserAsync(HttpContext.User);

           ViewData["Email"] = await _userManager.GetEmailAsync(x);
           var hotelId= _applicationDbContext.Hotels.Where(n => n.UserEntityId == x.Id)
                       .Select(n => n.HotelEntityId).FirstOrDefault();
           
            Program.HotelIdentity =
                  _applicationDbContext.Hotels.Where(u => u.UserEntityId == x.Id)
                  .Select(u => u.IdentityCertifcate).FirstOrDefault();


            ViewData["EditHotelProfileSetting"] = _Ihotel.HotelProfileSettingInfo(x.Id);


            var hotelPhoto = _applicationDbContext.Hotels
                    .Where(h => h.HotelEntityId == hotelId)
                    .Select(h => h.HotelPicture).FirstOrDefault();

            if (ModelState.IsValid)
                {

                   
                        if (Request.Form.Files.Count > 0)
                        {
                            var file = Request.Form.Files.FirstOrDefault();

                            //check file size and extension

                            using (var dataStream = new MemoryStream())
                            {
                                
                                await file.CopyToAsync(dataStream);
                                editHotelDto.HotelPicture = dataStream.ToArray();
                            //    hotelPhoto = editHotelDto.HotelPicture;
                               
                       // _applicationDbContext.SaveChanges();
                            }


                        }
                    
                    _Ihotel.EditeHotel(hotelId, editHotelDto);
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View(editHotelDto);

        }
        public async Task<IActionResult> AddHotelServicesAsync (Hotel_ExtraDto hotel_ExtraDto)
        {
            LayoutInfo();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                _Ihotel.AddServices(x.Id, hotel_ExtraDto);
            
            }
                return View();
        }
           
        }
    }

