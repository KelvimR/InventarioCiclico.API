using InventarioCiclico.API.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioCiclico.API.Controllers;

[ApiController]
[Route("/api/v1/empresas")]
public class EmpresaController : Controller
{
    private readonly EmpresaService _empresaService;
    public EmpresaController(EmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    /// <summary>
    /// Retorna a lista de empresas cadastradas.
    /// </summary>
    /// <returns>Lista de empresas</returns>

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListarEmpresas(CancellationToken cancellationToken)
    {
        var empresas = await _empresaService.ObterEmpresasAsync(cancellationToken);
        return Ok(empresas);
    }
}
