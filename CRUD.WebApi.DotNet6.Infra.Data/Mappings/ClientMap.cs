using CRUD.WebApi.DotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.WebApi.DotNet6.Infra.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            //builder.HasKey(x => x.ClientId);

            builder.Property(x => x.ClientId)
                .HasColumnName("clientid")
                .UseIdentityColumn();

            builder.Property(x => x.Email)
                .HasColumnName("email");

            builder.Property(x => x.PersonId)
                .HasColumnName("personid");
        }
    }
}
