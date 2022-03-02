using AutoMapper;
using MediatR;
using MvcTest.Application.Contracts;
using MvcTest.Application.DTOs;

namespace MvcTest.Application.Features.Pais.Queries;

public class GetPaisListRequest : IRequest<List<PaisDto>>
{
}