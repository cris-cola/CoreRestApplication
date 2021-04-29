using System.Collections.Generic;
using CoreRestApplication.Core.Data.Dto;

namespace CoreRestApplication.Core.Data.Interfaces
{
    public interface ICustomerRepository
    {
        CustomerDto DeleteCustomer(int id);
        IEnumerable<CustomerDto> GetCustomers();
        CustomerDto UpdateCustomerData(CustomerDto customerToUpdate);
        CustomerDto RegisterNewCustomer(CustomerDto customerModel);
        CustomerDto GetById(int id);
    }
}