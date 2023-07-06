using AutoMapper;
using My_Tables.Entities;
using MyDbProject;
using OurHotel.IRepo;
using OurHotels.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel1.Repo
{
    public class AdminRepo : IAdminRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AdminRepo(ApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ProfileAdminDto GetAdminInfo()
        {
            var res = _context.AdminEntities
          .OrderBy(a => a.Id)
          .Select(s => new ProfileAdminDto
          {
              FirstName = s.FirstName,
              LastName = s.LastName,
              Mobiel = s.Mobiel,
              DateOfBirth = s.DateOfBirth,
              Address = s.Address,
              City = s.City
          })
          .LastOrDefault();
            return res;
        }
        public void AddAdminProfile(AddAdminProfileDto addAdminProfileDto , byte[] l)
        {
            var res = _context.AdminEntities.FirstOrDefault();
           
                if (!string.IsNullOrEmpty(addAdminProfileDto.Address))
                {
                    res.Address = addAdminProfileDto.Address;
                }
                if (!string.IsNullOrEmpty(addAdminProfileDto.City))
                {
                    res.City = addAdminProfileDto.City;
                }
                if (addAdminProfileDto.DateOfBirth != res.DateOfBirth)
                {
                    res.DateOfBirth = addAdminProfileDto.DateOfBirth;
                }
                if (!string.IsNullOrEmpty(addAdminProfileDto.FirstName))
                {
                    res.FirstName = addAdminProfileDto.FirstName;
                }
                if (!string.IsNullOrEmpty(addAdminProfileDto.LastName))
                {
                    res.LastName = addAdminProfileDto.LastName;
                }
                if (!string.IsNullOrEmpty(addAdminProfileDto.Mobiel))
                {
                    res.Mobiel = addAdminProfileDto.Mobiel;
                }
                if(l !=null)
            {
                res.AdminPhoto = l;
            }
            //_context.AdminEntities.Add( new AdminEntity{
            // FirstName=addAdminProfileDto.FirstName,
            // LastName=addAdminProfileDto.LastName,
            // City=addAdminProfileDto.City,
            // Address=addAdminProfileDto.Address,
            //  DateOfBirth=addAdminProfileDto.DateOfBirth,
            //  Mobiel=addAdminProfileDto.Mobiel

            //});
            _context.SaveChanges();
        }

        public void AddAdminProfile(AddAdminProfileDto addAdminProfileDto)
        {
            var res = _context.AdminEntities.FirstOrDefault();

            if (!string.IsNullOrEmpty(addAdminProfileDto.Address))
            {
                res.Address = addAdminProfileDto.Address;
            }
            if (!string.IsNullOrEmpty(addAdminProfileDto.City))
            {
                res.City = addAdminProfileDto.City;
            }
            if (addAdminProfileDto.DateOfBirth != res.DateOfBirth)
            {
                res.DateOfBirth = addAdminProfileDto.DateOfBirth;
            }
            if (!string.IsNullOrEmpty(addAdminProfileDto.FirstName))
            {
                res.FirstName = addAdminProfileDto.FirstName;
            }
            if (!string.IsNullOrEmpty(addAdminProfileDto.LastName))
            {
                res.LastName = addAdminProfileDto.LastName;
            }
            if (!string.IsNullOrEmpty(addAdminProfileDto.Mobiel))
            {
                res.Mobiel = addAdminProfileDto.Mobiel;
            }
            _context.SaveChanges();
        }
    }
}
