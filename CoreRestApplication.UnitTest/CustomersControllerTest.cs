using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreRestApplication.Controllers;
using CoreRestApplication.Core.Data;
using CoreRestApplication.Data;
using CoreRestApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CoreRestApplication.UnitTest
{
    public class CustomersControllerTest
    {
        /*private int Id = 1;
        private string Name = "Name";
        private string Surname = "Surname";
        private string StreetName = "StreetName";
        private string StreetNumber = "123";
        private string ZipCode = "44287";
        private string PersonalNumber = "44287";

        private AddressDto Address => new AddressDto(StreetName, StreetNumber, ZipCode);
        private AddressModel AddressModel => new AddressModel(StreetName, StreetNumber, ZipCode);
        
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
        public void Delete_Request_Should_Return_Ok_When_Customer_Is_Deleted()
        {
            //Arrange
            var idToDelete = 2;
            var deletedCustomer = new MrGreenCustomerModel(idToDelete, Name, Surname, AddressModel, PersonalNumber);
            customerRepository.Setup(p => p.DeleteCustomer(It.IsAny<int>()))
                .Returns(deletedCustomer);

            //Act
            Task<ActionResult<CustomerModel>> result = Sut.Delete(idToDelete);

            var okResult = result.Result/* as OkObjectResult#1#;

            // Assert
            Assert.NotNull(okResult);
            var returnValue = okResult.Value as MrGreenCustomerModel;

           //Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(returnValue);
            Assert.Equal(2, returnValue.Id);
            Assert.Equal(Name, returnValue.Name);
            Assert.Equal(Surname, returnValue.Surname);
            Assert.Equal(PersonalNumber, returnValue.PersonalNumber);
            Assert.Equal(AddressModel.ZipCode, returnValue.Address.ZipCode);
            Assert.Equal(AddressModel.StreetName, returnValue.Address.StreetName);
            Assert.Equal(AddressModel.StreetNumber, returnValue.Address.StreetNumber);
        }

        [Fact]
        public void Put_Request_Should_Return_Not_Found()
        {
            //Arrange
            var customerToUpdate = new CustomerDto(Id, Name, Surname, Address);

            customerFactory.Setup(p => p.Register(It.IsAny<CustomerDto>()));
            customerFactory.Setup(p => p.Invoke()).Returns((MrGreenCustomerModel)null);

            customerRepository.Setup(p => p.UpdateCustomerData(It.IsAny<MrGreenCustomerModel>()))
                .Returns((MrGreenCustomerModel)null);

            //Act
            var result = Sut.Put(customerToUpdate);

            var notFoundResult = result.Result /*as NotFoundObjectResult#1#;

            Assert.NotNull(notFoundResult);
            /*Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Equal("User not found", notFoundResult.Value);#1#
        }

        [Fact]
        public void Put_Request_Should_Return_No_Content_When_Customer_Is_Updated()
        {
            //Arrange
            var customerToUpdate = new CustomerDto(Id, Name, Surname, Address);

            customerFactory.Setup(p => p.Register(It.IsAny<CustomerDto>()));
            customerFactory.Setup(p => p.Invoke()).Returns((MrGreenCustomerModel)null);

            customerRepository.Setup(p => p.UpdateCustomerData(It.IsAny<MrGreenCustomerModel>()))
                .Returns(new MrGreenCustomerModel(Id, Name, Surname, AddressModel, PersonalNumber));

            //Act
            var result = Sut.Put(customerToUpdate);

            //Assert
            var noContentResult = result.Result /*as NoContentResult#1#;

            Assert.NotNull(noContentResult);
            //Assert.Equal(204, noContentResult.StatusCode);
        }

        [Fact]
        public void Post_Request_Should_Return_Conflict_When_User_Already_Present()
        {
            //Arrange
            var newCustomer = new CustomerDto(Id, Name, Surname, Address);

            customerFactory.Setup(p => p.Register(It.IsAny<CustomerDto>()));
            customerFactory.Setup(p => p.Invoke()).Returns((MrGreenCustomerModel)null);

            customerRepository.Setup(p => p.RegisterNewCustomer(It.IsAny<MrGreenCustomerModel>()))
                .Returns((MrGreenCustomerModel)null);

            //Act
            var result = Sut.Post(newCustomer);
            
            //Assert
            var conflictResult = result.Result/* as ConflictObjectResult#1#;
            Assert.NotNull(conflictResult);
            //Assert.Equal(409, conflictResult.StatusCode);
            //Assert.Equal("Id already associated with a registered user", conflictResult.Value);
        }

        [Fact]
        public void Post_Request_Should_Register_New_Customer()
        {
            //Arrange
            var newCustomer = new CustomerDto(Id, Name, Surname, Address);
            
            customerFactory.Setup(p => p.Register(It.IsAny<CustomerDto>()));
            customerFactory.Setup(p => p.Invoke()).Returns((MrGreenCustomerModel)null);

            customerRepository.Setup(p => p.RegisterNewCustomer(It.IsAny<MrGreenCustomerModel>()))
                .Returns(new MrGreenCustomerModel(Id, Name, Surname, AddressModel, PersonalNumber));
            
            //Act
            var result = Sut.Post(newCustomer);
            
            //Assert
            var createdResult = result.Result /*as CreatedResult#1#; 

            Assert.NotNull(createdResult);
            //Assert.Equal(201, createdResult.StatusCode);
            //Assert.Equal("api/Customers/1", createdResult.Location);

            var registeredCustomer = createdResult.Value as MrGreenCustomerModel;

            Assert.NotNull(registeredCustomer);
            Assert.Equal(Name, registeredCustomer.Name);
            Assert.Equal(Surname, registeredCustomer.Surname);
            Assert.Equal(Id, registeredCustomer.Id);
            Assert.Equal(PersonalNumber, registeredCustomer.PersonalNumber);
        }
        
        [Fact]
        public void Get_By_Id_Request_Should_Return_NotFound_When_Searched_Customer_Is_Not_Present()
        {
            //Arrange
            customerRepository.Setup(p => p.GetById(It.IsAny<int>()))
                .Returns((CustomerModel) null);

            //Act
            var result = Sut.GetCustomer(0);

            var notFoundResult = result /*as NotFoundObjectResult#1#;

            Assert.NotNull(notFoundResult);
            //Assert.Equal("The id provided is not associated with any registered user", notFoundResult.Value);
        }

        [Fact]
        public void Get_By_Id_Request_Should_Return_Ok_With_Customer_When_Id_Is_Present()
        {
            //Arrange
            int id = 1;
            customerRepository.Setup(p => p.GetById(id))
                .Returns(new MrGreenCustomerModel{ Id = 1, Name = Name });

            //Act
            var result = Sut.GetCustomer(id);

            var okResult = result /*as OkObjectResult#1#;

            // Assert
            Assert.NotNull(okResult);
            //Assert.Equal(200, okResult.StatusCode);
            //var model = okResult.Value as CustomerModel;

            //Assert.NotNull(model);
            //Assert.Equal(1, model.Id);
            //Assert.Equal(Name, model.Name);
        }

        [Fact]
        public void Get_Request_Should_Return_Ok_With_Customers_When_Present()
        {
            //Arrange
            customerRepository.Setup(p => p.GetCustomers())
                .Returns(MockRepositoryResponse());
            
            //Act
            var result = Sut.GetAllCustomers();

            var okResult = result /*as OkObjectResult#1#;
            
            // Assert
            Assert.NotNull(okResult);
            //Assert.Equal(200, okResult.StatusCode);
            /*var model = okResult.Value as List<CustomerModel>;

            Assert.NotNull(model);
            Assert.Equal(2, model.Count);
            Assert.Equal("Winston", model[0].Name);
            Assert.Equal("Churchill", model[0].Surname);#1#
        }

        [Fact]
        public void Get_Request_Should_Return_NoContent_When_No_Customers_Are_Registered()
        {
            //Arrange
            customerRepository.Setup(p => p.GetCustomers())
                .Returns(new List<CustomerModel>());

            //Act
            var result = Sut.GetAllCustomers();

            var noContentResult = result /*as NoContentResult#1#;
            
            // Assert
            Assert.NotNull(noContentResult);
            //Assert.Equal(204, noContentResult.StatusCode);
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

        #endregion*/
    }
}
