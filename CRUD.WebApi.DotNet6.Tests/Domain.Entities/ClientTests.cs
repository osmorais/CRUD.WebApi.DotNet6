using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Validations;

namespace CRUD.WebApi.DotNet6.Tests.Domain.Entities
{
    public class ClientTests
    {
        //[Fact]
        [Theory]
        [InlineData(0,0, null, "teste@email.com")]
        [InlineData(0,0, "", "teste@email.com")]
        public void Test1_NameMustBeInformed(int clientId, int personId, string name, string email)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(clientId, personId, name, email);
            });


            //Assert
            Assert.Equal("Name must be informed.", result.Message);
        }

        //[Fact]
        [Theory]
        [InlineData(0, 0, "teste", "")]
        [InlineData(0, 0, "teste", null)]
        public void Test2_EmailMustBeInformed(int clientId, int personId, string name, string email)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(clientId, personId, name, email);
            });

            //Assert
            Assert.Equal("Email must be informed.", result.Message);
        }

        //[Fact]
        [Theory]
        [InlineData(-1, 0, "teste", "teste@email.com")]
        public void Test3_ClientIdWasInvalid(int clientId, int personId, string name, string email)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(clientId, personId, name, email);
            });


            //Assert
            Assert.Equal("ClientId was invalid.", result.Message);
        }

        //[Fact]
        [Theory]
        [InlineData(0, -1, "teste", "teste@email.com")]
        public void Test4_PersonIdWasInvalid(int clientId, int personId, string name, string email)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(clientId, personId, name, email);
            });


            //Assert
            Assert.Equal("PersonId was invalid.", result.Message);
        }

        //[Fact]
        [Theory]
        [InlineData(0, 0, "teste1", "teste@email.com")]
        [InlineData(0, 0, "teste1teste", "teste@email.com")]
        [InlineData(0, 0, "1", "teste@email.com")]
        public void Test5_NameMustHaveOnlyLetters(int clientId, int personId, string name, string email)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(clientId, personId, name, email);
            });


            //Assert
            Assert.Equal("Name must have only letters.", result.Message);
        }

        //[Fact]
        [Theory]
        [InlineData(0, 0, "teste", "teste@")]
        [InlineData(0, 0, "teste", "teste")]
        public void Test6_EmailMustBeInTheValidFormat(int clientId, int personId, string name, string email)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(clientId, personId, name, email);
            });


            //Assert
            Assert.Equal("Email must be in the valid format.", result.Message);
        }

        [Theory]
        [InlineData(0, 0, "teste!", "teste@email.com")]
        [InlineData(0, 0, "teste@", "teste@email.com")]
        [InlineData(0, 0, "teste#", "teste@email.com")]
        [InlineData(0, 0, "teste$%teste", "teste@email.com")]
        [InlineData(0, 0, "teste@teste", "teste@email.com")]
        [InlineData(0, 0, "teste!teste", "teste@email.com")]
        public void Test7_NameCannotHaveSpecialCharacters(int clientId, int personId, string name, string email)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(clientId, personId, name, email);
            });


            //Assert
            Assert.Equal("Name cannot have special characters.", result.Message);
        }
    }
}
