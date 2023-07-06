using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using My_Tables.Entities;
using MyDbProject;
using OurHotel.IRepo;
using OurHotels.Dto.Admin;
using OurHotels.Dto.Customer;
using OurHotels.Dto.Hotel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Our_Hotels1.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly IMapper _mapper;
        private readonly IHotelRepo _Ihotel;
        private readonly IAdminRepo _Iadmin;
        private readonly ICustomerRepo _Icustomer;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ILogger<LogoutModel> _logger;


        public AdminController(ApplicationDbContext applicationDbContext , IMapper mapper , 
            IHotelRepo Ihotel, ICustomerRepo Icustomer, UserManager<UserEntity> userManager, IAdminRepo Iadmin)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _Ihotel = Ihotel;
            _userManager = userManager;
            _Icustomer = Icustomer;
            _Iadmin = Iadmin;

    }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminProfile()
        {
            ViewData["ProfileAdminDto"] = _Iadmin.GetAdminInfo();
            Program.AdminPhoto= _applicationDbContext.AdminEntities.Select(l => l.AdminPhoto).FirstOrDefault();
            return View();
        }
        //public async Task<IActionResult> ChangeAdminPhotoAsync (byte[] photo )
        //{
        //    var AdminPhoto = _applicationDbContext.AdminEntities.Select(s=>s.AdminPhoto).FirstOrDefault();
        //    ViewData["AdminPhoto"] = _applicationDbContext.AdminEntities.Select(l => l.AdminPhoto).FirstOrDefault();
        //    if (Request.Form.Files.Count > 0)
        //    {
        //        var file = Request.Form.Files.FirstOrDefault();

        //        //check file size and extension

        //        using (var dataStream = new MemoryStream())
        //        {

        //            await file.CopyToAsync(dataStream);
        //            photo = dataStream.ToArray();
        //            AdminPhoto = photo;
        //          //  AdminPhoto = Program.AdminPhoto;
        //            _applicationDbContext.SaveChanges();
        //        }
        //    }
        //    return RedirectToAction("AdminProfile");
        //}
        public async Task<IActionResult> AddAdminProfileAsync(AddAdminProfileDto addAdminProfileDto)
        {
            byte[] l;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();

                //check file size and extension

                var dataStream = new MemoryStream();
           
                await file.CopyToAsync(dataStream);
                addAdminProfileDto.AdminPhoto = dataStream.ToArray();
            }
            l = addAdminProfileDto.AdminPhoto;
            if(l !=null)
            {
                _Iadmin.AddAdminProfile(addAdminProfileDto, l);
            }
            else
                _Iadmin.AddAdminProfile(addAdminProfileDto);
                return RedirectToAction("AdminProfile");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCAsync(AddCustomerDto addDto)
        {
            if (!ModelState.IsValid)
            {
                // There is a validation error
                var error = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid)?.Errors.FirstOrDefault();

                if (error != null)
                {
                    var errorMessage = error.ErrorMessage;
                    var fieldName = error.Exception?.Message ?? error.ErrorMessage;
                    // Use the error message and field name to display an error to the user
                }
            }

            // addDto.addUserDto = new OurHotels.Dto.User.AddUserDto();
            if (ModelState.IsValid)
            //if (addDto.Identity_Certificate != null && addDto.Identity_Certificate.Length > 0)
            //{
            //    // Process the uploaded file here (e.g., save it to a specific location)
            //}

            {
                if (addDto.gender.ToString() == 0 + "")
                {
                    ModelState.AddModelError("addDto.gender", "This field must be required ");
                    return View(addDto);
                }
                var user = new UserEntity { UserName = new MailAddress(addDto.Email).User, Email = addDto.Email, UserType = Type_Of.Customer };
                var passwordHash = _userManager.PasswordHasher.HashPassword(user, addDto.Password);
                user.PasswordHash = passwordHash;
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {

                    var userId = user.Id;

                    _Icustomer.AddCustomer(addDto, userId);


                    //_toastNotification.AddSuccessToastMessage("Customer added... ");
                    // TempData["Success"] = "The Customer has been added..";
                    return RedirectToAction("Index", "Admin");
                }
                return View("CreateCustomer", addDto);
            }

            //  AddCustomerDto = new AddCustomerDto();
            return View("CreateCustomer", addDto);
        }
        [HttpPost]
        public IActionResult EditC(int CustomerEntityId, UpdateCustomerDto Updatedto)
        {


            if (ModelState.IsValid)
            {
                _Icustomer.UpdateCustomer(Updatedto);
                TempData["Success"] = "The Customer has been Updated..";
                return RedirectToAction("Index");
            }

            return View(Updatedto);

        }
        public IActionResult DeleteC(int id)
        {


            _Icustomer.DeleteCustomer(id);
            TempData["Success"] = "The Customer has been removed";
            return RedirectToAction("Index");

        }
        public IActionResult Customers()
        {

            return View(_Icustomer.GetAllCustomer());

        }
        public IActionResult CreateCustomer()
        {
            return View();

        }
        public IActionResult EditCustomer()
        {
            return View();

        }
        public async Task<IActionResult> CreateAsync(AddHotelFromAdminDto addDto)
        {

            if (ModelState.IsValid)
            {

                var user = new UserEntity { UserName = new MailAddress(addDto.Email).User, Email = addDto.Email, UserType = Type_Of.Hotel };
                var passwordHash = _userManager.PasswordHasher.HashPassword(user, addDto.Password);
                user.PasswordHash = passwordHash;
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    // There is a validation error
                    var error = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid)?.Errors.FirstOrDefault();

                    if (error != null)
                    {
                        var errorMessage = error.ErrorMessage;
                        var fieldName = error.Exception?.Message ?? error.ErrorMessage;
                        // Use the error message and field name to display an error to the user
                    }
                }

                if (result.Succeeded)
                {

                    var userId = user.Id;

                    _Ihotel.AddHotelFromAdmin(addDto,userId);


                    //_toastNotification.AddSuccessToastMessage("Customer added... ");

                    return RedirectToAction("Index", "Admin");
                }
                return View("CreateHotel", addDto);
            }

            //  AddCustomerDto = new AddCustomerDto();


            return View("CreateHotel", addDto);
        }
        [HttpPost]
        public IActionResult Edit(int HotelEntityId, HotelDto Updatedto)
        {


            if (ModelState.IsValid)
            {
                _Ihotel.UpdateHotel(Updatedto);
                TempData["Success"] = "The Hotel has been Updated..";
                return RedirectToAction("Index");
            }

            return View(Updatedto);

        }
        public IActionResult Delet(int id)
        {


            _Ihotel.DeleteHotel(id);
            TempData["Success"] = "The Hotel has been removed";
            return RedirectToAction("Index");

        }
        public IActionResult Hotels()
        {

            return View(_Ihotel.GetAllHotel());

        }
        public IActionResult CreateHotel()
        {
            return View();

        }
        public IActionResult EditHotel()
        {
            return View();

        }


    }
}
