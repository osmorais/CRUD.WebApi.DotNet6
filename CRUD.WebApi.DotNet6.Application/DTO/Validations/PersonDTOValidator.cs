using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.WebApi.DotNet6.Application.DTO.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator() 
        { 
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome deve ser informado.");
        }


    }
}
