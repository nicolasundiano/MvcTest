using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MvcTest.Application.Contracts;
using MvcTest.Domain.Entities;
using MvcTest.Persistence.Repositories;

namespace MvcTest.Persistence;

public static class PersistenceServiceRegistration
{
    public static void ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ClienteDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine,
                new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information).EnableSensitiveDataLogging());
        
        services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPaisRepository, PaisRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();    }
}