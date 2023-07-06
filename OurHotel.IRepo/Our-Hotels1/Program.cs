using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OurHotels.Dto.Hotel;
using OurHotels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Our_Hotels1
{
    public class Program
    {
        public static LoginUserDto loginUserDto = new LoginUserDto();
        public static AddUserDto  AddUserDto = new AddUserDto();
        public static AddHotelDto addHotelDto = new AddHotelDto();

        //Hotel Layout Info
        public static string HotelName;
        public  static string HotelCity;
        public  static byte[] HotelPic;
        public  static byte[] HotelIdentity;
        public  static byte[] AdminPhoto;
        // Customer Layout Info 
        public static string CustomerName;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        

    }
}
