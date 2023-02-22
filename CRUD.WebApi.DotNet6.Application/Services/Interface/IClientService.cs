using CRUD.WebApi.DotNet6.Application.DTO;

namespace CRUD.WebApi.DotNet6.Application.Services.Interface
{
    public interface IClientService
    {
        Task<ResultService<ClientDTO>> CreateAsync(ClientDTO clientDTO);
    }
}
