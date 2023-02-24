using CRUD.WebApi.DotNet6.Application.DTO;

namespace CRUD.WebApi.DotNet6.Application.Services.Interface
{
    public interface IClientService
    {
        Task<ResultService<ClientDTO>> CreateClientAsync(ClientDTO clientDTO);
        Task<ResultService<ICollection<ClientDTO>>> ListAllClientsAsync();
        Task<ResultService<ClientDTO>> GetClientByEmailAsync(ClientDTO clientDTO);
        Task<ResultService> UpdateClientAsync(ClientDTO clientDTO);
        Task<ResultService> DeleteClientByEmailAsync(ClientDTO clientDTO);
    }
}
