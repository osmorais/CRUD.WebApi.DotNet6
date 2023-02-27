using CRUD.WebApi.DotNet6.Domain.Validations;
using System.Text.RegularExpressions;

namespace CRUD.WebApi.DotNet6.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }

        public Person() { }

        public Person(string Name)
        {
            this.Name = Name;

            this.Validation();
        }

        public Person(int PersonId, string Name)
        {
            this.Name = Name;
            this.PersonId = PersonId;

            this.Validation();
        }

        public void Validation()
        {
            DomainValidationException.When(this.PersonId < 0, "PersonId was invalid.");
            DomainValidationException.When(string.IsNullOrEmpty(this.Name), "Name must be informed.");
            DomainValidationException.When(hasSpecialCharacters(this.Name), "Name cannot have special characters.");

            int hasDigit = 0;
            foreach (char c in this.Name)
            {
                if (Char.IsDigit(c)) { hasDigit++; }
            }
            DomainValidationException.When(hasDigit > 0, "Name must have only letters.");
        }

        public static bool hasSpecialCharacters(string name)
        {
            return Regex.IsMatch(name, (@"[^a-zA-Z0-9' ']"));
        }
    }
}
