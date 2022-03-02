using MediatR;
using MvcTest.Application.DTOs;

namespace MvcTest.Application.Features.Cliente.Queries;

public class GetClienteListRequest : IRequest<List<ClienteDto>>
{
    
}