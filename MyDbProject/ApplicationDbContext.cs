using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My_Tables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace MyDbProject
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> TheUsers { get; set; }
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<Hotel_ExtraEntity>  Hotel_Extras { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<WebsiteEntity> WebsiteEntities { get; set; }
        public DbSet<Booking_ExtraEntity> Booking_Extras { get; set; }

        public DbSet<Extra_ServicesEntity> Extra_Services { get; set; }
        public DbSet<RoomEntity> RoomEntities { get; set; }
        public DbSet<AdminEntity> AdminEntities { get; set; }
        public DbSet<RoomImageEntity> RoomImageEntities{ get; set; }
        public DbSet<BillEntity> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //one to one
            builder.Entity<UserEntity>()
            .HasOne(b => b.HotelEntity)
            .WithOne(b => b.UserEntity)
            .HasForeignKey<HotelEntity>(o => o.UserEntityId);


            builder.Entity<UserEntity>()
           .HasOne(b => b.CustomerEntity)
           .WithOne(b => b.UserEntity)
           .HasForeignKey<CustomerEntity>(o => o.UserEntityId);

            //builder.Entity<UserEntity>()
            //    .HasOne(x => x.HotelEntity)
            //    .WithOne(x => x.UserEntity)
            //    .HasForeignKey<HotelEntity>(x => x.UserEntityId);

            //builder.Entity<UserEntity>()
            //    .HasOne(x => x.CustomerEntity)
            //    .WithOne(x => x.UserEntity)
            //    .HasForeignKey<CustomerEntity>(x => x.UserEntityId);

            // one to many 
            builder.Entity<HotelEntity>()
            .HasMany(b => b.RoomEntities)
            .WithOne(b => b.HotelEntity);

            builder.Entity<HotelEntity>()
             .HasMany(b => b.Hotel_ExtraEntities)
             .WithOne(b => b.HotelEntity);



            builder.Entity<Hotel_ExtraEntity>()
             .HasMany(b => b.Booking_ExtraEntities)
             .WithOne(b => b.Hotel_ExtraEntity);

            builder.Entity<Extra_ServicesEntity>()
            .HasMany(b => b.Hotel_ExtraEntities)
            .WithOne(b => b.Extra_ServicesEntity);

            builder.Entity<RoomEntity>()
           .HasMany(b => b.BookingEntities)
           .WithOne(b => b.RoomEntity);

            builder.Entity<BookingEntity>()
           .HasMany(b => b.Booking_ExtraEntities)
           .WithOne(b => b.BookingEntity);

            builder.Entity<CustomerEntity>()
           .HasMany(b => b.BillEntities)
           .WithOne(b => b.CustomerEntity);

            builder.Entity<RoomEntity>()
                .HasMany(b => b.Images)
                .WithOne(b => b.Room);

            builder.Entity<BillEntity>()
            .HasMany(b => b.BookingEntities)
           .WithOne(b => b.BillEntity);

            // for Entity
            builder.Entity<UserEntity>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

        }
    }
}
