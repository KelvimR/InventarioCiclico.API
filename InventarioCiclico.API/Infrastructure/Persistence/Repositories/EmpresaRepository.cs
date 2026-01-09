using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Domain.Entities;
using InventarioCiclico.API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InventarioCiclico.API.Infrastructure.Persistence.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly AppDbContext _context;
   

    public EmpresaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Empresa>> ObterEmpresasAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Empresas
            .AsNoTracking()
            .ToListAsync();        
    }

    public async Task<Empresa?> ObterEmpresaPorIdAsync(string id)
    {
        return await _context.Empresas
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmpresaId == id);
    }

    public async Task InserirEmpresasAsync(Empresa empresa)
    {
        _context.Add(empresa);
        await _context.SaveChangesAsync();
    }
}
