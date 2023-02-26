using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Validations;

namespace CRUD.WebApi.DotNet6.Tests.Domain.Entities
{
    public class PersonTests
    {
        //[Fact]
        [Theory]
        [InlineData(0, null)]
        [InlineData(0, "")]
        public void Test1_NameMustBeInformed(int personId, string name)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Person(personId, name);
            });


            //Assert
            Assert.Equal("Name must be informed.", result.Message);
        }

        //[Fact]
        [Theory]
        [InlineData(0, "teste1")]
        public void Test2_NameMustHaveOnlyLetters(int personId, string name)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Person(personId, name);
            });


            //Assert
            Assert.Equal("Name must have only letters.", result.Message);
        }

        //[Fact]
        [Theory]
        [InlineData(-1, "teste")]
        public void Test3_PersonIdWasInvalid(int personId, string name)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Person(personId, name);
            });


            //Assert
            Assert.Equal("PersonId was invalid.", result.Message);
        }

        [Theory]
        [InlineData(0, "teste!")]
        [InlineData(0, "teste@")]
        public void Test4_NameCannotHaveSpecialCharacters(int personId, string name)
        {
            //Arrange & Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Person(personId, name);
            });


            //Assert
            Assert.Equal("Name cannot have special characters.", result.Message);
        }
    }
}
