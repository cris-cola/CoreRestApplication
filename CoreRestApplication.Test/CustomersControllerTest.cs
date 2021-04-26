using System.Collections.Generic;
using CoreRestApplication.Controllers;
using CoreRestApplication.Data;
using CoreRestApplication.Model;
using Microsoft.AspNetCore.Mvc;
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
        public void ShouldGetCustomersWhenPresent()
        {
            customerRepository.Stub(x => x.GetCustomers())
                .Return(MockRepositoryResponse());

            IActionResult result = Sut.GetAllCustomers();
            var okResult = result as OkObjectResult;
            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        #region Privates
        
        private static List<CustomerModel> MockRepositoryResponse()
        {
            return new List<CustomerModel>
            {
                new MrGreenCustomerModel(1, "Winston", "Churchill", new AddressModel("Downey St.", "222", "60766"), "(222) 555-1212"){CustomerType = "MrGreen"},
                new RedBetCustomerModel(2, "Bon", "Jovi", new AddressModel("1234 St. Francisco", "122", "12345"), "Barcelona"){CustomerType = "RedBet"}
            };
        }

        #endregion
    }
}