using OurHotels.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.IRepo
{
    public interface ICustomerRepo
    {
        public void AddCustomer(AddCustomerDto addDto , string userId);
        public void UpdateCustomer(UpdateCustomerDto Updatedto);
        public void DeleteCustomer(int id);
        public CustomerDto GetCustomerById(int id);
        public int GetCustomersCount();
        public List<CustomerDto> GetAllCustomer();
    }
}
