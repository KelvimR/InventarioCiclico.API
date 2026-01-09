using InventarioCiclico.API.Application.Services;
using InventarioCiclico.API.Domain.Exceptions;
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
    /// <param name="cancellationToken">Token para cancelamento da requisição.</param>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListarEmpresas(CancellationToken cancellationToken)
    {
        var empresas = await _empresaService.ObterEmpresasAsync(cancellationToken);
        return Ok(empresas);
    }


    /// <summary>
    /// Retorna uma empresa pelo ID informado.
    /// </summary>
    /// <returns>Retorna a empresa encontrada ou 404 se não existir.</returns>
    /// <param name="id">ID da empresa a ser consultada.</param>
    /// <param name="cancellationToken">Token para cancelamento da requisição.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterEmpresaPorIdAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            var empresas = await _empresaService.ObterEmpresaPorIdAsync(id, cancellationToken);
            return Ok(empresas);
        }
        catch (BusinessException)
        {
            return NotFound($"Empresa {id} não localizada na base.");
        }
        
    }

}
