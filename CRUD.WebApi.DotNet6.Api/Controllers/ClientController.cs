using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebApi.DotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IPersonService _personService;

        public ClientController(IClientService clientService, IPersonService personService)
        {
            this._clientService = clientService;
            _personService = personService;
        }

        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] ClientDTO clientDTO)
        //{
        //    var result = await _clientService.CreateAsync(clientDTO);
        //    if (result.isSuccess)
        //        return Ok(result);

        //    return BadRequest(result);
        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDTO clientDTO)
        {
            var result = await _clientService.CreateAsync(clientDTO);
            if (result.isSuccess)
                    return Ok(result);

            return BadRequest(result);
        }
    }
}
