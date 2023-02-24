using CRUD.WebApi.DotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.WebApi.DotNet6.Domain.Repository
{
    public interface IClientRepository
    {
        Task<ICollection<Client>> GetAllAsync();
        Task<Client> GetClientByIdAsync(Client client);
        Task<Client> GetClientByEmailAsync(Client client);
        Task<Client> CreateClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task<Client> DeleteClientByEmailAsync(Client client);
    }
}
