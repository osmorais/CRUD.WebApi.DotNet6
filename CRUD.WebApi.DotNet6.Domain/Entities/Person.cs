using CRUD.WebApi.DotNet6.Domain.Validations;

namespace CRUD.WebApi.DotNet6.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }

        public Person () { }

        public Person (string Name)
        {
            this.Validation(Name);
        }

        public Person (int PersonId, string Name)
        {
            DomainValidationException.When(PersonId < 0, "PersonId was invalid.");
            this.PersonId = PersonId;

            this.Validation(Name);
        }

        private void Validation(string Name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(Name), "Name must be informed.");
            this.Name = Name;
        }
    }
}
