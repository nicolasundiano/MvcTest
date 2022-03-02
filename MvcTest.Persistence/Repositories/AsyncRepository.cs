using Microsoft.EntityFrameworkCore;
using MvcTest.Application.Contracts;
using MvcTest.Domain.Entities;
using MvcTest.Domain.Entities.Common;

namespace MvcTest.Persistence.Repositories;

public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseDomainEntity
{
    private readonly ClienteDbContext _context;

    public AsyncRepository(ClienteDbContext context)
    {
        _context = context;
    }
    
    public async Task<T> Add(T entity)
    {
        await _context.AddAsync(entity);
        return entity;
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    
    public async Task<T?> Get(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }
    
}