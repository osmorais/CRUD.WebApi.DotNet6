using CRUD.WebApi.DotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.WebApi.DotNet6.Infra.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");
            builder.HasKey(x => x.PersonId);

            builder.Property(x => x.PersonId)
                .HasColumnName("personid")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("nome");

        }
    }
}
