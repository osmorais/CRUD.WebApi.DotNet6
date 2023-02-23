using AutoMapper;
using CRUD.WebApi.DotNet6.Application.DTO;
using CRUD.WebApi.DotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.WebApi.DotNet6.Application.Mappings
{
    public class DTOToDomainMap : Profile
    {
        public DTOToDomainMap()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<ClientDTO, Client>();
        }
    }
}
