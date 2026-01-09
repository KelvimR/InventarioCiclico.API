using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Domain.Entities;

namespace InventarioCiclico.API.Application.Interfaces.Repositories;

public interface IEmpresaRepository
{
    Task<List<Empresa>> ObterEmpresasAsync(CancellationToken cancellationToken);

    Task<Empresa?> ObterEmpresaPorIdAsync(string id);

    Task InserirEmpresasAsync(Empresa empresa);
}
