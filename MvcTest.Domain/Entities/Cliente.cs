using MvcTest.Domain.Entities.Common;

namespace MvcTest.Domain.Entities;

public class Cliente : BaseDomainEntity
{
    public string? Nombre { get; set; }

    public int PaisId { get; set; }

    public virtual Pais? Pais { get; set; }

    public byte TipoCliente { get; set; }
}