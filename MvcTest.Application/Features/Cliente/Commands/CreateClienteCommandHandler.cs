using AutoMapper;
using MediatR;
using MvcTest.Application.Contracts;

namespace MvcTest.Application.Features.Cliente.Commands;

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = _mapper.Map<Domain.Entities.Cliente>(request.Cliente);

        await _clienteRepository.Add(cliente);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}