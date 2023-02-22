using CRUD.WebApi.DotNet6.Application.Mappings;
using CRUD.WebApi.DotNet6.Application.Services;
using CRUD.WebApi.DotNet6.Application.Services.Interface;
using CRUD.WebApi.DotNet6.Domain.Repository;
using CRUD.WebApi.DotNet6.Infra.Data.Context;
using CRUD.WebApi.DotNet6.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.WebApi.DotNet6.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMap));
            services.AddScoped<IPersonService, PersonService>();
            //services.AddScoped<IClientService, ClientService>();
            return services;
        }
    }
}
