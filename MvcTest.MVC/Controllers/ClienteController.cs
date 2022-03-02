using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcTest.Application.DTOs;
using MvcTest.Application.Features.Cliente.Commands;
using MvcTest.Application.Features.Cliente.Queries;
using MvcTest.Application.Features.Pais.Queries;
using MvcTest.MVC.Models;

namespace MvcTest.MVC.Controllers;

public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IMediator _mediator;

    public ClienteController(ILogger<ClienteController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var clientes = await _mediator.Send(new GetClienteListRequest());
        
        var paises = await _mediator.Send(new GetPaisListRequest());
        
        var selectListItem = paises.Select(pais => new SelectListItem {Value = pais.Id.ToString(), Text = pais.Nombre}).ToList();

        ViewBag.Paises = selectListItem;
        
        return View(clientes);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteClienteCommand {Id = id});
        return Json(Ok());
    }

    [HttpPost]
    public async Task<JsonResult> Guardar([FromBody] ClienteDto cliente)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v =>
                    v.Errors.Select(e => string.IsNullOrEmpty(e.ErrorMessage) ? e.Exception?.Message : e.ErrorMessage))
                .ToArray();
            
            return Json(new {Success=false, Errors = errors});
        }
        
        await _mediator.Send(new CreateClienteCommand {Cliente = cliente});
        return Json(new {Success=true, Redirect=@Url.Action("Index")});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}