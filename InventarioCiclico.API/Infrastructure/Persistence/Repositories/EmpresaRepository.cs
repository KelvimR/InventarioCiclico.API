using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventarioCiclico.API.Infrastructure.Persistence.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly AppDbContext _context;
   

    public EmpresaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Empresa>> ObterEmpresasAsync()
    {
        return await _context.Empresas
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Empresa?> ObterEmpresaPorIdAsync(int id)
    {
        return await _context.Empresas
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmpresaId == id);
    }

    public async Task<bool> InsereEmpresaAsync(Empresa empresa)
    {
        _context.Add(empresa);
        var linhasAfetadas = await _context.SaveChangesAsync();

        return linhasAfetadas > 0;
    }
}
