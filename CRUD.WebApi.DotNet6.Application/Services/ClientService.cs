using AutoMapper;
using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Application.DTO.Validations;
using CRUD.WebApi.DotNet6.Application.Services.Interface;
using CRUD.WebApi.DotNet6.Domain.Entities;
using CRUD.WebApi.DotNet6.Domain.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.WebApi.DotNet6.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this._clientRepository= clientRepository;
            this._mapper= mapper;
        }


        public async Task<ResultService<ClientDTO>> CreateAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null) { return ResultService.Fail<ClientDTO>("ClientDTO is null"); }

            var result = new ClientDTOValidator().Validate(clientDTO);
            if (!result.IsValid) { return ResultService.RequestError<ClientDTO>("ClientDTO was not valid", result); }

            var client = _mapper.Map<Client>(clientDTO);
            var data = await _clientRepository.CreateClientAsync(client);

            return ResultService.OK<ClientDTO>(_mapper.Map<ClientDTO>(data));
        }
    }
}
