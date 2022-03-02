using MvcTest.Application.Contracts;
using MvcTest.Domain.Entities;

namespace MvcTest.Persistence.Repositories;

public class PaisRepository : AsyncRepository<Pais>, IPaisRepository
{
    public PaisRepository(ClienteDbContext context) : base(context)
    {
    }
}