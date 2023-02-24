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

        public Client(int clientId, int personId, string name, string email)
        {
            DomainValidationException.When(clientId < 0, "ClientId was invalid.");
            DomainValidationException.When(personId < 0, "PersonId was invalid.");
            this.ClientId = clientId;
            base.PersonId = personId;

            Validation(name, email);
        }

        public Client(string name, string email)
        {
            Validation(name, email);
        }

        private void Validation(string name, string email)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be informed.");
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email must be informed.");
            DomainValidationException.When(!IsValidEmail(email), "Email must be in the valid format.");

            var hasDigit = false;
            foreach(char c in name) hasDigit = Char.IsDigit(c);
            DomainValidationException.When(hasDigit, "Name must have only letters.");


            base.Name = name;
            this.Email = email;
        }

        static public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
