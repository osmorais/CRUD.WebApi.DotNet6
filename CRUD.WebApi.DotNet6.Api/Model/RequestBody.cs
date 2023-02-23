using CRUD.WebApi.DotNet6.Application.DTO;

namespace CRUD.WebApi.DotNet6.Api.Model
{
    public class RequestBody
    {
        public PersonDTO personDTO{ get; set; }
        public ClientDTO clientDTO{ get; set; }
    }
}
