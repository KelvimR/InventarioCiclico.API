using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Domain.Entities;
using InventarioCiclico.API.Domain.Exceptions;

namespace InventarioCiclico.API.Application.Services;

public class CadastroService
{
    private readonly ICadastroRepository _repository;
    public CadastroService(ICadastroRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ConsultaCadastroDto>> ObterCadastroPorEmpresa(string empresaId, CancellationToken cancellationToken)
    {
        var cadastro = await _repository.ObterCadastroPorEmpresa(empresaId, cancellationToken);
        if (!cadastro.Any())
            throw new BusinessException("Nenhum item encontrado para a empresa.");

        return cadastro.Select(c => new ConsultaCadastroDto
        {
            EmpresaId = c.EmpresaId,
            EmpresaFilialId = c.EmpresaFilialId,
            NumeroPatrimonial = c.NumeroPatrimonial,
            TipoIncorporacaoId = c.TipoIncorporacaoId,
            Incorporacao = c.Incorporacao,
            CentroDeCustoId = c.CentroDeCustoId,
            ClasseId = c.ClasseId,
            ContaId = c.ContaId,
            DataAquisicao = c.DataAquisicao,
            DepreciacaoAcumulada = c.DepreciacaoAcumulada,
            DescricaoResumida = c.DescricaoResumida,
            ValorAquisicao = c.ValorAquisicao,
            ValorAtualizado = c.ValorAtualizado,
            ValorResidual = c.ValorResidual
        }).ToList();

    }

    public async Task<ConsultaCadastroDto> ObterCadastroPorNumeroPatrimonial(decimal numeroPatrimonial, CancellationToken cancellationToken)
    {
        var cadastro = await _repository.ObterCadastroPorNumeroPatrimonial(numeroPatrimonial, cancellationToken);
        if (cadastro == null)
            throw new BusinessException($"Não foi localizado cadastro na base para o item {numeroPatrimonial}.");

        var cadastroDto = new ConsultaCadastroDto
        {
            EmpresaId = cadastro.EmpresaId,
            EmpresaFilialId = cadastro.EmpresaFilialId,
            NumeroPatrimonial = cadastro.NumeroPatrimonial,
            TipoIncorporacaoId = cadastro.TipoIncorporacaoId,
            Incorporacao = cadastro.Incorporacao,
            CentroDeCustoId = cadastro.CentroDeCustoId,
            ClasseId = cadastro.ClasseId,
            ContaId = cadastro.ContaId,
            DataAquisicao = cadastro.DataAquisicao,
            DepreciacaoAcumulada = cadastro.DepreciacaoAcumulada,
            DescricaoResumida = cadastro.DescricaoResumida,
            ValorAquisicao = cadastro.ValorAquisicao,
            ValorAtualizado = cadastro.ValorAtualizado,
            ValorResidual = cadastro.ValorResidual
        };

        return cadastroDto;

    }


}
