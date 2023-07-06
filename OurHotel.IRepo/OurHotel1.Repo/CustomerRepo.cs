using AutoMapper;
using My_Tables.Entities;
using MyDbProject;
using OurHotel.IRepo;
using OurHotels.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.Repo
{
   public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerRepo(ApplicationDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public void AddCustomer(AddCustomerDto addDto , string userId)
        {

            addDto.UserEntityId = userId;
            var result = _mapper.Map<CustomerEntity>(addDto);
            _context.Customers.Add(result);
            _context.SaveChanges();

        }

        public void UpdateCustomer(UpdateCustomerDto Updatedto)
        {
            var res = _mapper.Map<CustomerEntity>(Updatedto);
            _context.Customers.Update(res);
            _context.SaveChanges();

        }

        public void DeleteCustomer(int id)
        {
            var result = _context.Customers.FirstOrDefault(x => x.CustomerEntityId == id);
            if (result != null)
            {
                _context.Customers.Remove(result);
                _context.SaveChanges();
            }
            else
            {
                // throw new NotFoundException();
            }


        }

        public CustomerDto GetCustomerById(int id)
        {
            var res = _context.Customers.FirstOrDefault(x => x.CustomerEntityId == id);
            if (res == null)
            {

                return null;
            }
            else
            {
                var result = _mapper.Map<CustomerDto>(res);
                return result;
            }
        }

        public int GetCustomersCount()
        {
            return _context.Customers.Count();
        }
        public List<CustomerDto> GetAllCustomer()
        {
            //// Create a source object

            //var source = new CustomerEntity() {
            //    FirstName =,
            //    LastName = ,

            //};

            //// Map the source object to a destination object
            //var destination = _mapper.Map<CustomerDto>(source);

            //// Use the mapped destination object
            //// ...

            //return destination;


            List<CustomerDto> customrers = new List<CustomerDto>();
            var result = _context.Customers.ToList();
            foreach (var item in result)
            {
                customrers.Add(_mapper.Map<CustomerDto>(item));
            }
            return customrers;
        }

       
    }
}

