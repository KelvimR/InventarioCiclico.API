using InventarioCiclico.API.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioCiclico.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CadastroController : Controller
{
    private readonly CadastroService _cadastroService;
    public CadastroController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    /// <summary>
    /// Retorna os itens cadastrados de acordo com a empresa informada.
    /// </summary>
    /// <returns>Retorna os itens encontrados para empresa ou 404 se não existir.</returns>
    /// <param name="empresaId">ID da empresa a ser consultada.</param>
    /// <param name="cancellationToken">Token para cancelamento da requisição.</param>
    [HttpGet("{empresaId}", Name = "ObterItensPorEmpresa")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObteItensPorEmpresa(string empresaId, CancellationToken cancellationToken)
    {
        var cadastro = await _cadastroService.ObterCadastroPorEmpresa(empresaId, cancellationToken);
        return Ok(cadastro);
    }

    /// <summary>
    /// Retorna os itens cadastrados de acordo com o numero patrimonial, os itens podem ter mais de uma incorporacao.
    /// </summary>
    /// <returns>Retorna os itens encontrados por numero patrimonial ou 404 se não existir.</returns>
    /// <param name="numeroPatrimonial">ID da empresa a ser consultada.</param>
    /// <param name="cancellationToken">Token para cancelamento da requisição.</param>
    [HttpGet("{numeroPatrimonial:decimal}", Name = "ObterItensPorNumeroPatrimonial")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterItensPorNumeroPatrimonial(decimal numeroPatrimonial, CancellationToken cancellationToken)
    {
        var cadastro = await _cadastroService.ObterCadastroPorNumeroPatrimonial(numeroPatrimonial, cancellationToken);
        return Ok(cadastro);
    }

}
