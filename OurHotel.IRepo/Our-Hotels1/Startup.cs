using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using My_Tables.Entities;
using MyDbProject;
using NToastNotify;
using OurHotel.IRepo;
using OurHotel1.Repo;
using OurHotel1.Repo.Profiles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.Extensions.FileProviders;
using System.IO;
using OurHotel.Repo;
using OurHotel.Repo.Profiles;

namespace Our_Hotels1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
       


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddAutoMapper(typeof(HotelProfile).Assembly);
            services.AddScoped<IHotelRepo, HotelRepo>();
         
            
            services.AddAutoMapper(typeof(RoomProfile).Assembly);
            services.AddScoped<IRoomRepo, RoomRepo>();

            services.AddScoped<IAdminRepo, AdminRepo>();

            // services.AddScoped<IHotelRepo, HotelRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddAutoMapper(typeof(CustomerProfile).Assembly);

            //   services.AddAutoMapper(typeof(HotelProfile).Assembly);



            //services.Configure<JWT>(Configuration.GetSection("JWT"));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCuture = new[]
                {
                new CultureInfo("ar"),
                new CultureInfo("en"),
            };
                options.DefaultRequestCulture = new RequestCulture(culture: "ar", uiCulture: "ar");
                options.SupportedCultures = supportedCuture;
                options.SupportedUICultures = supportedCuture;
            });

          


            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                PreventDuplicates = true,
                CloseButton = true
                // CloseDuration=10
            }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            
            services.AddDatabaseDeveloperPageExceptionFilter();
            //IdentityRole<int>
            services.AddIdentity<UserEntity, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultUI()
              .AddDefaultTokenProviders();
          
           
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
          services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , SignInManager<UserEntity> signInManager)
        {
           



                if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //var lockapp= app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            var localizerOption = ((IApplicationBuilder)app).ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizerOption.Value);

           // app.UseRequestLocalization(lockapp.Value);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
