using System.Collections.Generic;
using System.Linq;
using CoreRestApplication.Model;

namespace CoreRestApplication.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<CustomerModel> Customers;

        public CustomerRepository()
        {
            Customers = new List<CustomerModel>
            {
                new MrGreenCustomerModel(1, "Winston", "Churchill", new AddressModel("Downey St.", "222", "60766"), "(222) 555-1212"){ CustomerType = "MrGreen" },
                new RedBetCustomerModel(3, "Bon", "Jovi", new AddressModel("1234 St. Francisco", "122", "12345"), "Barcelona"){ CustomerType = "RedBet" }
            };
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            return Customers.OrderBy(i => i.Id);
        }

        public CustomerModel GetById(int id)
        {
            return Customers.FirstOrDefault(i => i.Id == id);
        }

        public CustomerModel RegisterNewCustomer(CustomerModel customerModel)
        {
            var customerToRegister = GetById(customerModel.Id);
            if (customerToRegister != null) return null;
            Customers.Add(customerModel);
            return customerModel;
        }
        
        public CustomerModel DeleteCustomer(int id)
        {
            var customerToDelete = GetById(id); ;
            if (customerToDelete == null) return null;    
            Customers.Remove(customerToDelete);
            return customerToDelete;
        }

        public CustomerModel UpdateCustomerData(CustomerModel customerToUpdate)
        {
            var deletedCustomer = DeleteCustomer(customerToUpdate.Id);
            if (deletedCustomer == null) return null;
            Customers.Add(customerToUpdate);
            return customerToUpdate;
        }
    }

    public interface ICustomerRepository
    {
        CustomerModel DeleteCustomer(int id);
        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel UpdateCustomerData(CustomerModel customerToUpdate);
        CustomerModel RegisterNewCustomer(CustomerModel customerModel);
        CustomerModel GetById(int id);
    }
}
