using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using My_Tables.Entities;
using Our_Hotels1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyDbProject;
using System.Security.Claims;

namespace Our_Hotels1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        public readonly ApplicationDbContext _applicationDbContext;
        public HomeController(ILogger<HomeController> logger, UserManager<UserEntity> userManager,
          ApplicationDbContext applicationDbContext, SignInManager<UserEntity>signInManager
            )
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var x = await _userManager.GetUserAsync(HttpContext.User);
            if( x!=null)
            {
                if (x.Id != null)
                {
                    var type = _applicationDbContext.Users.Where(s => s.Id == x.Id)
                     .Select(m => m.UserType).FirstOrDefault();
                    if (type == My_Tables.Entities.Type_Of.Hotel)
                    {
                        Program.loginUserDto.type_Of = "Hotel";
                    }
                    else if (type == My_Tables.Entities.Type_Of.Customer)
                    {
                        Program.loginUserDto.type_Of = "Customer";
                    }
                    else
                    {
                        Program.loginUserDto.type_Of = "Admin";
                    }

                }
            }
           
            else
            {
                return View();
            }

            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            
            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public  void  LayoutInfo()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if(Program.loginUserDto.type_Of=="Hotel")
                {
                    var UserEntityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Program.HotelName = _applicationDbContext.Hotels.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => n.HotelName).FirstOrDefault();
                  
                }
                else if (Program.loginUserDto.type_Of == "Customer")
                {
                    var UserEntityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Program.CustomerName = _applicationDbContext.Customers.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => new { n.FirstName , n.LastName}).FirstOrDefault().ToString();
                }
            
            }
            
        }

    }
}
