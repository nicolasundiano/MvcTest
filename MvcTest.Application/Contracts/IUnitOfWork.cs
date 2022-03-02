namespace MvcTest.Application.Contracts;

public interface IUnitOfWork : IDisposable
{
    IPaisRepository PaisRepository { get; }
    IClienteRepository ClienteRepository { get; }

    Task Save();
}