using AutoMapper;
using MediatR;
using MvcTest.Application.Contracts;
using MvcTest.Application.DTOs;

namespace MvcTest.Application.Features.Cliente.Queries;

public class GetClienteListRequestHandler : IRequestHandler<GetClienteListRequest, List<ClienteDto>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public GetClienteListRequestHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ClienteDto>> Handle(GetClienteListRequest request, CancellationToken cancellationToken)
    {
        var clientes = await _clienteRepository.GetAllWithPais();
        return _mapper.Map<List<ClienteDto>>(clientes);
    }
}