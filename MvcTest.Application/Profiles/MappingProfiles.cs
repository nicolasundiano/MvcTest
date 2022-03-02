using AutoMapper;
using MvcTest.Application.DTOs;
using MvcTest.Domain.Entities;
using MvcTest.Domain.Enums;

namespace MvcTest.Application.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Cliente, ClienteDto>()
            .ForMember(x => x.PaisNombre, x => x.MapFrom(y => y.Pais!.Nombre))
            .ForMember(x => x.TipoCliente, x => x.MapFrom(y => (TipoCliente)y.TipoCliente));
        
        CreateMap<ClienteDto, Cliente>()
            .ForMember(x => x.TipoCliente, x => x.MapFrom(y => (byte)y.TipoCliente));;
    }
}