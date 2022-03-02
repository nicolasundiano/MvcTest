using System.ComponentModel.DataAnnotations;
using MvcTest.Application.DTOs.Common;
using MvcTest.Domain.Enums;

namespace MvcTest.Application.DTOs;

public class ClienteDto : BaseDto
{
    [Required(ErrorMessage = "Nombre Requerido")]
    public string? Nombre { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un Pais")]
    public int PaisId { get; set; }

    public string? PaisNombre { get; set; }

    public TipoCliente TipoCliente { get; set; }
}