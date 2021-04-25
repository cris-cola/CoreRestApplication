using CoreRestApplication.Controllers;
using CoreRestApplication.Data;
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
            Assert.Pass();
        }
    }
}