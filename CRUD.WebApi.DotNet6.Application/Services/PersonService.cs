using AutoMapper;
using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Application.DTO.Validations;
using CRUD.WebApi.DotNet6.Application.Services.Interface;
using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Repository;

namespace CRUD.WebApi.DotNet6.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService()
        {

        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null) { return ResultService.Fail<PersonDTO>("PersonDTO is null");  }

            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid) { return ResultService.RequestError<PersonDTO>("PersonDTO was not valid", result); }

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreatePersonAsync(person);

            return ResultService.OK<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }
    }
}
