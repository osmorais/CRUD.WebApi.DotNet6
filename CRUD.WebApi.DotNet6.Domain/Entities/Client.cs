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

            this.ClientId = clientId;
            base.PersonId = personId;
            base.Name = name;
            this.Email = email;

            this.Validation();
        }

        public void Validation()
        {
            DomainValidationException.When(this.ClientId < 0, "ClientId was invalid.");
            DomainValidationException.When(base.PersonId < 0, "PersonId was invalid.");
            DomainValidationException.When(string.IsNullOrEmpty(base.Name), "Name must be informed.");
            DomainValidationException.When(string.IsNullOrEmpty(this.Email), "Email must be informed.");
            DomainValidationException.When(!IsValidEmail(this.Email), "Email must be in the valid format.");

            var hasDigit = false;
            foreach(char c in base.Name) hasDigit = Char.IsDigit(c);
            DomainValidationException.When(hasDigit, "Name must have only letters.");
        }

        public static bool IsValidEmail(string email)
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
