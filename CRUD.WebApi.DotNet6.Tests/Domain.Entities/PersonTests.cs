using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Validations;

namespace CRUD.WebApi.DotNet6.Tests.Domain.Entities
{
    public class PersonTests
    {


        [Fact]
        public void Test1_NameMustBeInformed()
        {
            //Arrange & Act
            var resultIsNull = Assert.Throws<DomainValidationException>(() =>
            {
                new Person(0, null);
            });
            var resultIsEmpty = Assert.Throws<DomainValidationException>(() =>
            {
                new Person(0, "");
            });


            //Assert
            Assert.Equal("Name must be informed.", resultIsNull.Message);
            Assert.Equal("Name must be informed.", resultIsEmpty.Message);
        }

        [Fact]
        public void Test4_PersonIdWasInvalid()
        {
            //Arrange & Act
            var resultIsNegative = Assert.Throws<DomainValidationException>(() =>
            {
                new Person(-1, "teste");
            });


            //Assert
            Assert.Equal("PersonId was invalid.", resultIsNegative.Message);
        }
    }
}
