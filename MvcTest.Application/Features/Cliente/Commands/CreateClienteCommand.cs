using MediatR;
using MvcTest.Application.DTOs;

namespace MvcTest.Application.Features.Cliente.Commands;

public class CreateClienteCommand : IRequest
{
    public ClienteDto Cliente { get; set; }
}