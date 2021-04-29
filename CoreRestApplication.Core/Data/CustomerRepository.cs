using System.Collections.Generic;
using System.Linq;
using CoreRestApplication.Core.Data.Dto;
using CoreRestApplication.Core.Data.Interfaces;

namespace CoreRestApplication.Core.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<CustomerDto> _customers;

        public CustomerRepository()
        {
            _customers = new List<CustomerDto>
            {
                new RedBet(1, "Winston", "Churchill", new AddressDto("Downey St.", "222", "60766"), "(222) 555-1212"){ CustomerType = "MrGreen" },
                new MrGreen(3, "Bon", "Jovi", new AddressDto("1234 St. Francisco", "122", "12345"), "Barcelona"){ CustomerType = "RedBet" }
            };
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _customers.OrderBy(i => i.Id);
        }

        public CustomerDto GetById(int id)
        {
            return _customers.FirstOrDefault(i => i.Id == id);
        }

        public CustomerDto RegisterNewCustomer(CustomerDto customerModel)
        {
            var customerToRegister = GetById(customerModel.Id);
            if (customerToRegister != null) return null;
            _customers.Add(customerModel);
            return customerModel;

        }
        
        public CustomerDto DeleteCustomer(int id)
        {
            var customerToDelete = GetById(id); ;
            if (customerToDelete == null) return null;    
            _customers.Remove(customerToDelete);
            return customerToDelete;
        }

        public CustomerDto UpdateCustomerData(CustomerDto customerToUpdate)
        {
            var deletedCustomer = DeleteCustomer(customerToUpdate.Id);
            if (deletedCustomer == null) return null;
            _customers.Add(customerToUpdate);
            return customerToUpdate;
        }
    }
}
