using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Domain.Entities;
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

    public async Task<List<Empresa>> ObterEmpresas()
    {
        return await _repository.ObterEmpresasAsync();
    }
}
