using System.Collections.Generic;
using CoreRestApplication.Controllers;
using CoreRestApplication.Data;
using CoreRestApplication.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace CoreRestApplication.Test
{
    public class CustomersControllerTest
    {
        private ICustomerRepository customerRepository;
        private ICustomerFactory customerFactory;

        private CustomersController Sut;

        [SetUp]
        public void Setup()
        {
            customerRepository = MockRepository.GenerateMock<ICustomerRepository>();
            customerFactory = MockRepository.GenerateMock<ICustomerFactory>();
            
            Sut = new CustomersController(customerRepository, customerFactory);
        }

        [Test]
        public void ShouldPassTest()
        {
            customerRepository.Stub(x => x.GetCustomers())
                .Return(new List<CustomerModel>{new MrGreenCustomerModel(), new RedBetCustomerModel()});
            
            Assert.Pass();
        }
    }
}