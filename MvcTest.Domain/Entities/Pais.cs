using MvcTest.Domain.Entities.Common;

namespace MvcTest.Domain.Entities;

public class Pais : BaseDomainEntity
{
    public string? Nombre { get; set; }

    public virtual HashSet<Cliente>? Clientes { get; set; }
}