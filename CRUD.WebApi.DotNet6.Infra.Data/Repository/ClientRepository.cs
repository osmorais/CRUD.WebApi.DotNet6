using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Repository;
using CRUD.WebApi.DotNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebApi.DotNet6.Infra.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        public readonly ApplicationDbContext _db;
        public async Task<List<Client>> GetAllAsync()
        {
            return await _db.Client.ToListAsync();
        }

        public async Task<Client> GetClientByEmailAsync(Client client)
        {
            return await _db.Client.FirstOrDefaultAsync(x => x.Email == client.Email);
        }

        public async Task<Client> GetClientByIdAsync(Client client)
        {
            return await _db.Client.FirstOrDefaultAsync(x => x.ClientId == client.ClientId);
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            _db.Add(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Client> DeleteClientAsync(Client client)
        {
            _db.Remove(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            _db.Update(client);
            await _db.SaveChangesAsync();
            return client;
        }
    }
}
