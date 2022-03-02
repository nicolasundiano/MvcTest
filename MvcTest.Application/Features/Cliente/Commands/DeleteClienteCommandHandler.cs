using MediatR;
using MvcTest.Application.Contracts;

namespace MvcTest.Application.Features.Cliente.Commands;

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.Get(request.Id);
        
        if (cliente == null)
            throw new Exception();

        await _clienteRepository.Delete(cliente);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}