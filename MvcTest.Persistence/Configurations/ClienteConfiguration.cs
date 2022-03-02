using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcTest.Domain.Entities;

namespace MvcTest.Persistence.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.Property(x => x.Nombre).HasMaxLength(256);

        builder.HasData(new Cliente
        {
            Id = 1,
            Nombre = "Nicolas Undiano",
            PaisId = 3,
            TipoCliente = 1
        });
    }
}