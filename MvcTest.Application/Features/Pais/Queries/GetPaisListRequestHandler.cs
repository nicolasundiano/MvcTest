using AutoMapper;
using MediatR;
using MvcTest.Application.Contracts;
using MvcTest.Application.DTOs;

namespace MvcTest.Application.Features.Pais.Queries;

public class GetPaisListRequestHandler : IRequestHandler<GetPaisListRequest, List<PaisDto>>
{
    private readonly IPaisRepository _paisRepository;
    private readonly IMapper _mapper;

    public GetPaisListRequestHandler(IPaisRepository paisRepository, IMapper mapper)
    {
        _paisRepository = paisRepository;
        _mapper = mapper;
    }
    
    public async Task<List<PaisDto>> Handle(GetPaisListRequest request, CancellationToken cancellationToken)
    {
        var paises = await _paisRepository.GetAll();
        return _mapper.Map<List<PaisDto>>(paises);
    }
}