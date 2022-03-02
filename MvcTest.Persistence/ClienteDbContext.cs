using Microsoft.EntityFrameworkCore;
using MvcTest.Domain.Entities;

namespace MvcTest.Persistence;

public class ClienteDbContext : DbContext
{
    public ClienteDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteDbContext).Assembly);
    }

    public DbSet<Pais>? Paises { get; set; }
    public DbSet<Cliente>? Clientes { get; set; }
}