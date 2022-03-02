using MediatR;

namespace MvcTest.Application.Features.Cliente.Commands;

public class DeleteClienteCommand : IRequest
{
    public int Id { get; set; }
}