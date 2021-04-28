using System.Collections.Generic;
using CoreRestApplication.Core.Data;

namespace CoreRestApplication.Core.Interfaces
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