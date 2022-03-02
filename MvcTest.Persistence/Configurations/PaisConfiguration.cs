using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcTest.Domain.Entities;

namespace MvcTest.Persistence.Configurations;

public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.Property(x => x.Nombre).HasMaxLength(256);

        builder.HasData(new List<Pais>
        {
            new()
            {
                Id = 1,
                Nombre = "Estados Unidos"
            },
            new()
            {
                Id = 2,
                Nombre = "Puerto Rico"
            },
            new()
            {
                Id = 3,
                Nombre = "Otros"
            }
        });
    }
}