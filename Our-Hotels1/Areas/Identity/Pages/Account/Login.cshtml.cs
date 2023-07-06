using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using My_Tables.Entities;
using System.Net.Mail;
using OurHotels.Dto.User;
using MyDbProject;
using System.Security.Claims;
using Microsoft.Extensions.Localization;
using Our_Hotels1.Resources.Views.Shared;
//using Microsoft.AspNet.Identity;

namespace Our_Hotels1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<LayoutResource> layoutLocalizer;

        public LoginModel(SignInManager<UserEntity> signInManager,
            ILogger<LoginModel> logger,
            UserManager<UserEntity> userManager, ApplicationDbContext context, IStringLocalizer<LayoutResource> layoutLocalizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            this.layoutLocalizer = layoutLocalizer;
        }

        [BindProperty]
        public LoginUserDto Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Email or Username")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var username = new EmailAddressAttribute().IsValid(Input.Email) ? new MailAddress(Input.Email).User : Input.Email;

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var userByUsername = await _userManager.FindByNameAsync(Input.Email);
                var userByEmail = await _userManager.FindByEmailAsync(Input.Email);
                var userId = userByUsername != null ? userByUsername.Id : userByEmail.Id;
                var result = await _signInManager.PasswordSignInAsync(username, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var mm = _context.Users.Where(x => x.Email == username || x.UserName == username).Select(m => m.UserType).FirstOrDefault();

                    // string currentUserId =User.Identity.GetUserId();
                    var stateOfUser = _context.Hotels.Where(c => c.UserEntity.Id == userId).Select(s => s.State).FirstOrDefault();
                     var  UserEntityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    // var userId = User.Identity.GetUserId();
                    //4bc1da23-a957-45c6-8fea-8a6f64d2c4a4
                   
                        if(User.Identity.IsAuthenticated)
                    { 
                                        //
                    }
                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        // User is authenticated
                    }
                    var temp = HttpContext.Request.Headers.Keys;
                    
                    //HttpContext.User = '4bc1da23-a957-45c6-8fea-8a6f64d2c4a4';
                    //await _userManager.GetUserAsync(HttpContext.User);
                    //var z = await _userManager.GetUserAsync(HttpContext.User);
                    //var user = await _userManager.GetUserAsync(User);
                    //var user2 = await _userManager.FindByIdAsync(z.Id);
                    
                    

                   // var jj = State.confirmed;
                     //   var jj = _context.Hotels.Where(m => m.UserEntityId == userId).Select(c => c.State).FirstOrDefault();
                        //  var stateOfUser = _context.Hotels.Where(c=>c.UserEntityId== userId).Select(s=>s.State);
                        Input.type_Of = userByUsername != null ? userByUsername.UserType.ToString() : userByEmail.UserType.ToString();

                        if (Input.type_Of == "Customer")
                        {
                            Program.loginUserDto.type_Of = "Customer";
                        }

                        else if (Input.type_Of == "Hotel" && stateOfUser == State.confirmed)
                        {
                            Program.loginUserDto.type_Of = "Hotel";
                        }
                        else if (Input.type_Of == "Hotel" && stateOfUser != State.confirmed)
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                           await _signInManager.SignOutAsync();
                           _logger.LogInformation("User logged out.");
                        return Page();
                        }
                        else if (Input.type_Of == "3")
                        {
                            Program.loginUserDto.type_Of = "Admin";
                        }
                        //  Program.loginUserDto.type_Of = Input.type_Of;
                        _logger.LogInformation("User logged in.");
                  
                    return LocalRedirect(returnUrl);
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }
            
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
