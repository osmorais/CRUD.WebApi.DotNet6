using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Repository;
using CRUD.WebApi.DotNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebApi.DotNet6.Infra.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public async Task<List<Person>> GetAllAsync()
        {
            return await _db.Person.ToListAsync();
        }
        public async Task<Person> CreatePersonAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<Person> DeletePersonAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public Task<Person> GetPersonByIdAsync(Person person)
        {
            return _db.Person.FirstOrDefaultAsync(x => x.PersonId == person.PersonId);
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
            return person;
        }
    }
}
