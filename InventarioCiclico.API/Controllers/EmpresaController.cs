using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Application.Services;
using InventarioCiclico.API.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace InventarioCiclico.API.Controllers;

[ApiController]
[Route("api/v1/empresas")]
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
    [HttpGet(Name = "ListarEmpresas")]
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
    [HttpGet("{id}", Name = "ObterEmpresaPorId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterEmpresaPorIdAsync([FromRoute] string id, CancellationToken cancellationToken)
    {
        var empresas = await _empresaService.ObterEmpresaPorIdAsync(id, cancellationToken);
        return Ok(empresas);
    }

    /// <summary>
    /// Cria uma nova empresa no sistema.
    /// </summary>
    /// <param name="dto">
    /// Objeto contendo os dados necessários para o cadastro da empresa.
    /// </param>
    /// <param name="cancellationToken">
    /// Token para cancelamento da requisição.
    /// </param>
    /// <returns>
    /// Retorna <see cref="CreatedAtActionResult"/> quando a empresa é criada com sucesso.
    /// </returns>
    /// <response code="201">Empresa criada com sucesso.</response>
    /// <response code="400">Dados inválidos enviados na requisição.</response>
    /// <response code="409">Empresa já cadastrada na base.</response>
    /// <response code="500">Erro interno no servidor.</response>
    [HttpPost(Name = "InserirEmpresa")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InserirEmpresaAsync([FromBody] InsereEmpresaDto dto, CancellationToken cancellationToken)
    {
        await _empresaService.CriarEmpresaAsync(dto, cancellationToken);
        return CreatedAtRoute(
            "ObterEmpresaPorId",
            new
            {
                id = dto.EmpresaId
            }, dto);
    }

    /// <summary>
    /// Remove o cadastro de uma empresa da base de dados.
    /// </summary>    
    /// <param name="id">ID da empresa a ser removida.</param>
    /// <param name="usuario">Usuário responsável por remover a empresa da base.</param>
    /// <param name="cancellationToken">Token para cancelamento da requisição.</param>
    /// <response code="204">Empresa removida com sucesso.</response>
    /// <response code="404">Empresa não encontrada.</response>
    [HttpDelete("{id}/{usuario}", Name = "RemoverEmpresa")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveEmpresaAsync([FromRoute] string id, string usuario, CancellationToken cancellationToken)
    {
        await _empresaService.RemoverEmpresaAsync(id, usuario, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Atualiza o cadastro de uma empresa da base de dados.
    /// </summary>
    /// <param name="dto">
    /// Objeto contendo os dados necessários para o atualização da empresa.
    /// </param>
    /// <param name="cancellationToken">
    /// Token para cancelamento da requisição.
    /// </param>
    /// <response code="204">Empresa atualizada com sucesso.</response>    
    /// <response code="404">Empresa não localizada na base.</response>
    /// <response code="500">Erro interno no servidor.</response>
    [HttpPut(Name ="AtualizarEmpresa")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AtualizaEmpresa([FromBody] AtualizaEmpresaDto dto, CancellationToken cancellationToken)
    {
        await _empresaService.AtualizarEmpresaAsync(dto,cancellationToken);
        return NoContent();
    }

}
