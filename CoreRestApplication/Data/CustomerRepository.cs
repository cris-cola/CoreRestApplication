using System.Collections.Generic;
using System.Linq;
using CoreRestApplication.Model;

namespace CoreRestApplication.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<ICustomerModel> Customers;

        public CustomerRepository()
        {
            Customers = new List<ICustomerModel>
            {
                new MrGreenCustomerModel(1, "Winston", "Churchill", new AddressModel("Downey St.", "222", "60766"), "(222) 555-1212"){CustomerType = "MrGreen"},
                new RedBetCustomerModel(3, "Bon", "Jovi", new AddressModel("1234 St. Francisco", "122", "12345"), "Barcelona"){CustomerType = "RedBet"}
            };
        }

        public IEnumerable<ICustomerModel> GetCustomers()
        {
            return Customers.OrderBy(i => i.Id);
        }

        public ICustomerModel GetById(int id)
        {
            return Customers.FirstOrDefault(i => i.Id == id);
        }

        public ICustomerModel RegisterNewCustomer(ICustomerModel customerModel)
        {
            var customerToRegister = GetById(customerModel.Id);
            if (customerToRegister != null) return null;
            Customers.Add(customerModel);
            return customerModel;
        }
        
        public ICustomerModel DeleteCustomer(int id)
        {
            var customerToDelete = GetById(id); ;
            if (customerToDelete == null) return null;    
            Customers.Remove(customerToDelete);
            return customerToDelete;
        }

        public ICustomerModel UpdateCustomerData(ICustomerModel customerToUpdate)
        {
            var deletedCustomer = DeleteCustomer(customerToUpdate.Id);
            if (deletedCustomer == null) return null;
            Customers.Add(customerToUpdate);
            return customerToUpdate;
        }
    }

    public interface ICustomerRepository
    {
        ICustomerModel DeleteCustomer(int id);
        IEnumerable<ICustomerModel> GetCustomers();
        ICustomerModel UpdateCustomerData(ICustomerModel customerToUpdate);
        ICustomerModel RegisterNewCustomer(ICustomerModel customerModel);
        ICustomerModel GetById(int id);
    }
}
