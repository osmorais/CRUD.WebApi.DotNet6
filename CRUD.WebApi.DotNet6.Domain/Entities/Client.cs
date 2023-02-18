using CRUD.WebApi.DotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DomainValidationException.When(ClientId < 0, "Id do cliente invalido.");
            DomainValidationException.When(PersonId < 0, "Id da pessoa invalido.");
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
            DomainValidationException.When(string.IsNullOrEmpty(Name), "O nome deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(Email), "O email deve ser informado.");
            base.Name = Name;
            this.Email = Email;
        }
    }
}
