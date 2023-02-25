using AutoMapper;
using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Application.Services;
using CRUD.WebApi.DotNet6.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.WebApi.DotNet6.Tests.Application.Services
{
    public class ClientServiceTests
    {
        private ClientService clientService;

        public ClientServiceTests()
        {
            this.clientService =
                new ClientService(new Mock<IClientRepository>().Object, new Mock<IMapper>().Object);
        }

        //[Fact]
        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        public void Test1_CreateClientAsync_SendingValidId(int clientid, int personid)
        {
            //Arrange
            var client = new ClientDTO() { ClientId = clientid, PersonId = personid };

            //Act
            var result = clientService.CreateClientAsync(client);

            //Assert
            Assert.Equal("Unable to create a client that already has an Id.", result.Result.message);
        }

        [Fact]
        public void Test2_CreateClientAsync_SendingNullDTO()
        {
            //Arrange & Act
            var result = clientService.CreateClientAsync(null);

            //Assert
            Assert.Equal("ClientDTO is null.", result.Result.message);
        }


        //[Fact]
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test3_CreateClientAsync_SendingNullOrEmptyEmail(string email)
        {
            //Arrange
            var clientDTO = new ClientDTO()
            {
                ClientId = 0,
                Email= email,
                Name= "teste",
                PersonId = 0
            };   

            //Act
            var result = clientService.CreateClientAsync(clientDTO);

            //Assert
            Assert.Equal("ClientDTO was not valid", result.Result.message);
        }
    }
}
