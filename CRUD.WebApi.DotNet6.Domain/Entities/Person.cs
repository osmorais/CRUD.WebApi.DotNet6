using CRUD.WebApi.DotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.WebApi.DotNet6.Domain.Entities
{
    public abstract class Person
    {
        protected int PersonId { get; set; }
        protected string Name { get; set; }

        public Person () { }

        public Person (string Name)
        {
            this.Validation(Name);
        }

        public Person (int PersonId, string Name)
        {
            DomainValidationException.When(PersonId < 0, "Id da pessoa invalido.");
            this.PersonId = PersonId;

            this.Validation(Name);
        }

        private void Validation(string Name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(Name), "O nome deve ser informado.");
            this.Name = Name;
        }
    }
}
