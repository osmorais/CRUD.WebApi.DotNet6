using CRUD.WebApi.DotNet6.Domain.Validations;

namespace CRUD.WebApi.DotNet6.Domain.Entities
{
    public class Client : Person
    {
        public int ClientId { get; set; }
        public string Email { get; set; }

        public Client()
        {

        }

        public Client(int ClientId, int PersonId, string Name, string Email)
        {
            DomainValidationException.When(ClientId < 0, "ClientId was invalid.");
            DomainValidationException.When(PersonId < 0, "PersonId was invalid.");
            this.ClientId = ClientId;
            base.PersonId = PersonId;

            Validation(Name, Email);
        }

        public Client(string Name, string Email)
        {
            Validation(Name, Email);
        }

        private void Validation(string Name, string Email)
        {
            DomainValidationException.When(string.IsNullOrEmpty(Name), "Name must be informed.");
            DomainValidationException.When(string.IsNullOrEmpty(Email), "Email must be informed.");
            base.Name = Name;
            this.Email = Email;
        }
    }
}
