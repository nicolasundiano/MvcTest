using Microsoft.EntityFrameworkCore;
using MvcTest.Application.Contracts;
using MvcTest.Domain.Entities;

namespace MvcTest.Persistence.Repositories;

public class ClienteRepository : AsyncRepository<Cliente>, IClienteRepository
{
    private readonly ClienteDbContext _context;

    public ClienteRepository(ClienteDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Cliente>> GetAllWithPais()
    {
        return await _context.Clientes!.Include(x => x.Pais).ToListAsync();
    }
}