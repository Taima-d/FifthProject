using My_Tables.Entities;
using OurHotels.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace OurHotel.Repo.Profiles
{
    public class CustomerProfile : Profile
    {
   
        public CustomerProfile()
        {
            //GetCustomerDto
            CreateMap<CustomerEntity, CustomerDto>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

           


            //AddCustomerDto
            CreateMap<AddCustomerDto, CustomerEntity>();
            // UpdateCustomerDto
            CreateMap<UpdateCustomerDto, CustomerEntity>();
        }
    }
}
