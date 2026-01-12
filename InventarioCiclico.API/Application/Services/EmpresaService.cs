using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Application.Interfaces.Services;
using InventarioCiclico.API.Domain.Entities;
using InventarioCiclico.API.Domain.Exceptions;
using InventarioCiclico.API.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InventarioCiclico.API.Application.Services;

public class EmpresaService
{
    private readonly IEmpresaRepository _repository;
    private readonly ILogService _logService;

    public EmpresaService(IEmpresaRepository repository, ILogService logService)
    {
        _repository = repository;
        _logService = logService;
    }

    public async Task<List<EmpresaDto>> ObterEmpresasAsync(CancellationToken cancellationToken)
    {
        var empresas = await _repository.ObterEmpresasAsync(cancellationToken);
        if (!empresas.Any())
            throw new BusinessException("Nenhuma empresa encontrada.");

        return empresas.Select(e => new EmpresaDto
        {
            EmpresaId = e.EmpresaId,
            CGC = e.CGC,
            Endereco = e.Endereco,
            RazaoSocial = e.RazaoSocial,    
            Telefone = e.Telefone
        }).ToList();

    }

    public async Task<EmpresaDto> ObterEmpresaPorIdAsync (string id, CancellationToken cancellationToken)
    {
        var obtemEmpresa = await _repository.ObterEmpresaPorIdAsync(id, cancellationToken);
        if (obtemEmpresa == null)
            throw new NotFoundException($"Empresa {id} não localizada na base.", id);

        var empresaDto = new EmpresaDto
        {
            EmpresaId = obtemEmpresa.EmpresaId,
            RazaoSocial = obtemEmpresa.RazaoSocial,
            CGC = obtemEmpresa.CGC,
            Endereco = obtemEmpresa.Endereco,
            Telefone = obtemEmpresa.Telefone
        };

        return empresaDto;

    }

    public async Task CriarEmpresaAsync(InsereEmpresaDto dto, CancellationToken cancellationToken)
    {
        var verificaEmpresa = await _repository.ObterEmpresaPorIdAsync(dto.EmpresaId, cancellationToken);
        if (verificaEmpresa != null)
            throw new BusinessException($"Empresa {dto.EmpresaId} já está cadastrada na base. Favor verificar! ");

        var empresa = new Empresa
        {
            EmpresaId = dto.EmpresaId,
            CGC = dto.CGC,
            Endereco = dto.Endereco,
            Telefone = dto.Telefone,
            RazaoSocial = dto.RazaoSocial
        };

        await _repository.InserirEmpresasAsync(empresa, cancellationToken);

        await _logService.InserirLogAsync(new Log
        {
            EmpresaId = dto.EmpresaId,
            Operacao = $"Criação da empresa {dto.EmpresaId}.",
            Usuario = dto.Usuario
        }, cancellationToken);

    }

    public async Task RemoverEmpresaAsync(string id, string usuario, CancellationToken cancellationToken)
    {
        var verificaEmpresa = await _repository.ObterEmpresaPorIdAsync(id, cancellationToken);
        if (verificaEmpresa == null)
            throw new NotFoundException($"Empresa {id} não localizada na base! Favor validar. ", id);

        await _repository.RemoverEmpresaAsync(id, cancellationToken);

        await _logService.InserirLogAsync(new Log
        {
            EmpresaId = id,
            Operacao = $"Removendo empresa {id} da base de dados.",
            Usuario = usuario
        }, cancellationToken);

    }

    public async Task AtualizarEmpresaAsync(AtualizaEmpresaDto dto, CancellationToken cancellationToken)
    {
        var verificaEmpresa = await _repository.ObterEmpresaPorIdAsync(dto.EmpresaId,cancellationToken);
        if (verificaEmpresa == null)
            throw new NotFoundException($"Empresa", dto.EmpresaId);     

        await _repository.AtualizarEmpresaAsync(dto, cancellationToken);

        await _logService.InserirLogAsync(new Log
        {
            EmpresaId = dto.EmpresaId,
            Operacao = $"Empresa {dto.EmpresaId} atualizada na base de dados.",
            Usuario = dto.Usuario
        }, cancellationToken);
    }
    
}
