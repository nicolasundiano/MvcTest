using MvcTest.Domain.Entities;

namespace MvcTest.Application.Contracts;

public interface IClienteRepository : IAsyncRepository<Cliente>
{
    Task<IReadOnlyList<Cliente>> GetAllWithPais();
}