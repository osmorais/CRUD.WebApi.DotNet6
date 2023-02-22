using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebApi.DotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService= personService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);
            if(result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
