using System;
using System.Collections.Generic;
using AutoMapper;
using CoreRestApplication.Model;

namespace CoreRestApplication.Data
{
    public class CustomerFactory : ICustomerFactory
    {
        private string CustomerType;
        private readonly IMapper Mapper;
        private Dictionary<string, Func<ICustomerModel>> Customers;
        
        public CustomerFactory(IMapper mapper)
        {
            Mapper = mapper;
        }

        public void Register(CustomerDto newCustomer)
        {
            CustomerType = newCustomer.CustomerType;
            Customers = new Dictionary<string, Func<ICustomerModel>>
            {
                ["RedBet"] = () => MapCustomer<RedBetCustomerModel>(newCustomer),
                ["MrGreen"] = () => MapCustomer<MrGreenCustomerModel>(newCustomer)
            };
        }

        public ICustomerModel Invoke()
        {
            return Customers[CustomerType].Invoke();
        }

        public T MapCustomer<T>(CustomerDto customer)
        {
            return Mapper.Map<T>(customer);
        }
    }
    
    public interface ICustomerFactory
    {
        ICustomerModel Invoke();
        void Register(CustomerDto newCustomer);
    }
}