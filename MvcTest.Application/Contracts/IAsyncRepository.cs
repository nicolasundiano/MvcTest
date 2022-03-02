using MvcTest.Domain.Entities.Common;

namespace MvcTest.Application.Contracts;

public interface IAsyncRepository<T> where T : BaseDomainEntity
{
    Task<T?> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task Delete(T entity);
}