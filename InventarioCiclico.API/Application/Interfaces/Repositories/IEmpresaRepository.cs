using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Domain.Entities;

namespace InventarioCiclico.API.Application.Interfaces.Repositories;

public interface IEmpresaRepository
{
    Task<List<Empresa>> ObterEmpresasAsync();

    Task<Empresa?> ObterEmpresaPorIdAsync(int id);

    Task<bool> InsereEmpresaAsync(Empresa empresa);
}
