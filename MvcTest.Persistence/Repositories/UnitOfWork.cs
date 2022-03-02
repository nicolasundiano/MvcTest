using MvcTest.Application.Contracts;

namespace MvcTest.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClienteDbContext _context;
    private IPaisRepository _paisRepository;
    private IClienteRepository _clienteRepository;

    public UnitOfWork(ClienteDbContext context, IPaisRepository paisRepository, IClienteRepository clienteRepository)
    {
        _context = context;
        _paisRepository = paisRepository;
        _clienteRepository = clienteRepository;
    }
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public IPaisRepository PaisRepository => new PaisRepository(_context);
    public IClienteRepository ClienteRepository => new ClienteRepository(_context);
    
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}