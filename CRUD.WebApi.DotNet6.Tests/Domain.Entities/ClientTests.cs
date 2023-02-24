using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Validations;

namespace CRUD.WebApi.DotNet6.Tests.Domain.Entities
{
    public class ClientTests
    {
        [Fact]
        public void Test1_NameMustBeInformed()
        {
            //Arrange & Act
            var resultIsNull = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(0, 0, null, "teste@email.com");
            });
            var resultIsEmpty = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(0, 0, "", "teste@email.com");
            });


            //Assert
            Assert.Equal("Name must be informed.", resultIsNull.Message);
            Assert.Equal("Name must be informed.", resultIsEmpty.Message);
        }

        [Fact]
        public void Test2_EmailMustBeInformed()
        {
            //Arrange & Act
            var resultIsNull = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(0, 0, "teste", null);
            });
            var resultIsEmpty = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(0, 0, "teste", "");
            });


            //Assert
            Assert.Equal("Email must be informed.", resultIsNull.Message);
            Assert.Equal("Email must be informed.", resultIsEmpty.Message);
        }

        [Fact]
        public void Test3_ClientIdWasInvalid()
        {
            //Arrange & Act
            var resultIsNegative = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(-1, 0, "teste", "teste@email.com");
            });


            //Assert
            Assert.Equal("ClientId was invalid.", resultIsNegative.Message);
        }

        [Fact]
        public void Test4_PersonIdWasInvalid()
        {
            //Arrange & Act
            var resultIsNegative = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(0, -1, "teste", "teste@email.com");
            });


            //Assert
            Assert.Equal("PersonId was invalid.", resultIsNegative.Message);
        }

        [Fact]
        public void Test5_NameMustHaveOnlyLetters()
        {
            //Arrange & Act
            var resultHasNumber = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(0, 0, "teste1", "teste@email.com");
            });


            //Assert
            Assert.Equal("Name must have only letters.", resultHasNumber.Message);
        }

        [Fact]
        public void Test6_EmailMustBeInTheValidFormat()
        {
            //Arrange & Act
            var resultIncorretEmail = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(0, 0, "teste", "teste@");
            });
            var resultIncorretEmail2 = Assert.Throws<DomainValidationException>(() =>
            {
                new Client(0, 0, "teste", "teste");
            });


            //Assert
            Assert.Equal("Email must be in the valid format.", resultIncorretEmail.Message);
            Assert.Equal("Email must be in the valid format.", resultIncorretEmail2.Message);
        }
    }
}
