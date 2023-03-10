using AutoMapper;
using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Application.DTO.Validations;
using CRUD.WebApi.DotNet6.Application.Services.Interface;
using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Repository;
using CRUD.WebApi.DotNet6.Domain.Validations;

namespace CRUD.WebApi.DotNet6.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this._clientRepository = clientRepository;
            this._mapper = mapper;
        }

        public async Task<ResultService<ClientDTO>> CreateClientAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null) 
                return ResultService.Fail<ClientDTO>("ClientDTO is null.");

            if (clientDTO.ClientId > 0 || clientDTO.PersonId > 0)
                return ResultService.Fail<ClientDTO>("Unable to create a client that already has an Id.");

            var validationResult = new ClientDTOValidator().Validate(clientDTO);
            if (!validationResult.IsValid) 
                return ResultService.RequestError<ClientDTO>("ClientDTO was not valid", validationResult);

            try 
            {
                var client = _mapper.Map<Client>(clientDTO);

                var clientExits = await _clientRepository.GetClientByEmailAsync(client);
                if (clientExits != null) return ResultService.Fail<ClientDTO>("Cannot insert an email that already exists");

                var data = await _clientRepository.CreateClientAsync(client);

                return ResultService.OK<ClientDTO>(_mapper.Map<ClientDTO>(data));
            }
            catch (Exception error)
            {
                return ResultService.RequestError<ClientDTO>(error.Message);
            }
        }

        public async Task<ResultService> DeleteClientByEmailAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null || string.IsNullOrEmpty(clientDTO.Email)) 
                return ResultService.Fail("ClientDTO or Email is null or empty");

            if (!Client.IsValidEmail(clientDTO.Email))
                return ResultService.Fail("Email must be in the valid format.");

            try
            {
                var client = new Client() { Email = clientDTO.Email };

                client = await _clientRepository.GetClientByEmailAsync(client);
                if (client == null) return ResultService.Fail("Client to delete was not found");

                await _clientRepository.DeleteClientByEmailAsync(client);

                return ResultService.OK(string.Format("Client id {0} was deleted with success", client.ClientId));
            }
            catch (Exception error)
            {
                return ResultService.RequestError(error.Message);
            }
        }

        public async Task<ResultService> UpdateClientAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null)
                return ResultService.Fail("ClientDTO is null");

            if (clientDTO.ClientId <= 0 || clientDTO.PersonId <= 0)
                return ResultService.Fail<ClientDTO>("Unable to update a client that does not have an Id.");

            var validationResult = new ClientDTOValidator().Validate(clientDTO);
            if (!validationResult.IsValid) 
                return ResultService.RequestError("ClientDTO was not valid", validationResult);

            try
            {
                var client = _mapper.Map<Client>(clientDTO);

                client = await _clientRepository.GetClientByIdAsync(client);

                if (client == null) 
                    return ResultService.Fail("Client to update was not found");

                client = _mapper.Map<ClientDTO, Client>(clientDTO, client);

                var clientExits = await _clientRepository.GetClientByEmailAsync(client);
                if (clientExits != null) return ResultService.Fail<ClientDTO>("Cannot update to an email that already exists");

                await _clientRepository.UpdateClientAsync(client);

                return ResultService.OK(string.Format("Client id {0} was updated with success", client.ClientId));
            }
            catch (Exception error)
            {
                return ResultService.RequestError(error.Message);
            }
        }

        public async Task<ResultService<ClientDTO>> GetClientByEmailAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null || string.IsNullOrEmpty(clientDTO.Email)) 
                return ResultService.Fail<ClientDTO>("ClientDTO or Email is null or empty");

            if (!Client.IsValidEmail(clientDTO.Email))
                return ResultService.Fail<ClientDTO>("Email must be in the valid format.");

            try
            {
                var client = new Client() { Email = clientDTO.Email };

                var data = await _clientRepository.GetClientByEmailAsync(client);
                if (data == null)
                    return ResultService.OK<ClientDTO>("Client was not found");

                return ResultService.OK<ClientDTO>(_mapper.Map<ClientDTO>(data));
            }
            catch (Exception error)
            {
                return ResultService.RequestError<ClientDTO>(error.Message);
            }
        }

        public async Task<ResultService<ICollection<ClientDTO>>> ListAllClientsAsync()
        {
            try
            {
                var data = await _clientRepository.GetAllAsync();

                return ResultService.OK<ICollection<ClientDTO>>(_mapper.Map<ICollection<ClientDTO>>(data));
            }
            catch (Exception error)
            {
                return ResultService.RequestError<ICollection<ClientDTO>>(error.Message);
            }
        }
    }
}
