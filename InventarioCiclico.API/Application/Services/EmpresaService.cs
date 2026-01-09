using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Domain.Entities;
using InventarioCiclico.API.Domain.Exceptions;
using InventarioCiclico.API.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InventarioCiclico.API.Application.Services;

public class EmpresaService
{
    private readonly IEmpresaRepository _repository;

    public EmpresaService(IEmpresaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EmpresaDto>> ObterEmpresasAsync(CancellationToken cancellationToken)
    {
        //Recebo entidade e retorno dto
        //Garantindo a seguranca da base
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
}
