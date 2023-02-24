using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebApi.DotNet6.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            this._clientService = clientService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                var result = await _clientService.CreateClientAsync(clientDTO);
                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ListAllClients()
        {
            try
            {
                var result = await _clientService.ListAllClientsAsync();
                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetClientByEmail(string email)
        {
            try
            {
                var clientDTO = new ClientDTO() { Email = email };
                var result = await _clientService.GetClientByEmailAsync(clientDTO);
                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                var result = await _clientService.UpdateClientAsync(clientDTO);
                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteClientByEmail(string email)
        {
            try
            {
                var clientDTO = new ClientDTO() { Email = email };
                var result = await _clientService.DeleteClientByEmailAsync(clientDTO);
                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
