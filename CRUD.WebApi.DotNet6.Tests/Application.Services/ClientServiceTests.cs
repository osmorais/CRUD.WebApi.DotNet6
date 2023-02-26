using AutoMapper;
using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Application.Services;
using CRUD.WebApi.DotNet6.Domain.Repository;
using Moq;

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

        #region CreateClientAsync
        //[Fact]
        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        public void CreateClientAsync_SendingValidId(int clientid, int personid)
        {
            //Arrange
            var client = new ClientDTO() { ClientId = clientid, PersonId = personid };

            //Act
            var result = clientService.CreateClientAsync(client);

            //Assert
            Assert.Equal("Unable to create a client that already has an Id.", result.Result.message);
        }

        [Fact]
        public void CreateClientAsync_SendingNullDTO()
        {
            //Arrange & Act
            var result = clientService.CreateClientAsync(null);

            //Assert
            Assert.Equal("ClientDTO is null.", result.Result.message);
        }


        //[Fact]
        [Theory]
        [InlineData("teste", "")]
        [InlineData("teste", null)]
        public void CreateClientAsync_SendingNullOrEmptyEmail(string name, string email)
        {
            //Arrange
            var clientDTO = new ClientDTO() { Name = name, Email= email };   

            //Act
            var result = clientService.CreateClientAsync(clientDTO);

            //Assert
            Assert.Equal("ClientDTO was not valid", result.Result.message);
        }

        #endregion

        #region DeleteClientByEmailAsync
        [Fact]
        private void DeleteClientByEmailAsync_SendingNullClientDTO()
        {
            var result = clientService.DeleteClientByEmailAsync(null);

            Assert.Equal("ClientDTO or Email is null or empty", result.Result.message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        private void DeleteClientByEmailAsync_SendingNullOrEmptyEmail(string email)
        {
            var clientDTO = new ClientDTO() { Email = email };

            var result = clientService.DeleteClientByEmailAsync(clientDTO);

            Assert.Equal("ClientDTO or Email is null or empty", result.Result.message);
        }

        [Theory]
        [InlineData("teste@teste")]
        private void DeleteClientByEmailAsync_SendingNonexistentEmail(string email)
        {
            var clientDTO = new ClientDTO() { Email = email };

            var result = clientService.DeleteClientByEmailAsync(clientDTO);

            Assert.Equal("Client to delete was not found", result.Result.message);
        }

        [Theory]
        [InlineData("teste@")]
        [InlineData("teste")]
        private void DeleteClientByEmailAsync_SendingInvalidEmail(string email)
        {
            var clientDTO = new ClientDTO() { Email = email };

            var result = clientService.DeleteClientByEmailAsync(clientDTO);

            Assert.Equal("Email must be in the valid format.", result.Result.message);
        }

        #endregion

        #region UpdateClientAsync
        [Fact]
        private void UpdateClientAsync_SendingNullClientDTO()
        {
            var result = clientService.UpdateClientAsync(null);

            Assert.Equal("ClientDTO is null", result.Result.message);
        }

        [Theory]
        [InlineData("teste", "")]
        [InlineData("teste", null)]
        private void UpdateClientAsync_SendingNullOrEmptyEmail(string name, string email)
        {
            var clientDTO = new ClientDTO() { Name = name, Email = email };

            var result = clientService.UpdateClientAsync(clientDTO);

            Assert.Equal("ClientDTO was not valid", result.Result.message);
        }

        [Theory]
        [InlineData("teste","teste@teste")]
        private void UpdateClientAsync_SendingNonexistentEmail(string name, string email)
        {
            var clientDTO = new ClientDTO() { Name = name, Email = email };

            var result = clientService.UpdateClientAsync(clientDTO);

            Assert.Equal("Client to update was not found", result.Result.message);
        }
        #endregion

        #region GetClientByEmailAsync

        [Fact]
        private void GetClientByEmailAsync_SendingNullClientDTO()
        {
            var result = clientService.GetClientByEmailAsync(null);

            Assert.Equal("ClientDTO or Email is null or empty", result.Result.message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        private void GetClientByEmailAsync_SendingNullOrEmptyEmail(string email)
        {
            var clientDTO = new ClientDTO() { Email = email };

            var result = clientService.GetClientByEmailAsync(clientDTO);

            Assert.Equal("ClientDTO or Email is null or empty", result.Result.message);
        }

        [Theory]
        [InlineData("teste@teste")]
        private void GetClientByEmailAsync_SendingNonexistentEmail(string email)
        {
            var clientDTO = new ClientDTO() { Email = email };

            var result = clientService.GetClientByEmailAsync(clientDTO);

            Assert.Equal("Client was not found", result.Result.message);
        }

        [Theory]
        [InlineData("teste@")]
        [InlineData("teste")]
        private void GetClientByEmailAsync_SendingInvalidEmail(string email)
        {
            var clientDTO = new ClientDTO() { Email = email };

            var result = clientService.GetClientByEmailAsync(clientDTO);

            Assert.Equal("Email must be in the valid format.", result.Result.message);
        }
        #endregion
    }
}
