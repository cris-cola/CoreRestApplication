using System;
using System.Collections.Generic;
using CoreRestApplication.Controllers;
using CoreRestApplication.Data;
using CoreRestApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;
using Rhino.Mocks;
using Xunit;

namespace CoreRestApplication.UnitTest
{
    public class CustomersControllerTest
    {
        private readonly Mock<ICustomerRepository> customerRepository;
        private readonly Mock<ICustomerFactory> customerFactory;

        private CustomersController Sut;

        public CustomersControllerTest()
        {
            customerRepository = new Mock<ICustomerRepository>();
            customerFactory = new Mock<ICustomerFactory>();
            
            Sut = new CustomersController(customerRepository.Object, customerFactory.Object);
        }

        [Fact]
        public void ShouldGetCustomersWhenPresent()
        {
            customerRepository.Setup(p => p.GetCustomers())
                .Returns(MockRepositoryResponse());
            
            IActionResult result = Sut.GetAllCustomers();
            var okResult = result as OkObjectResult;
            
            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
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
