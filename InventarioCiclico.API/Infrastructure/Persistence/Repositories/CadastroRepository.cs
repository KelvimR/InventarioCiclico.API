using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventarioCiclico.API.Infrastructure.Persistence.Repositories;

public class CadastroRepository : ICadastroRepository
{
    private readonly AppDbContext _context;
    public CadastroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cadastro>> ObterCadastroPorEmpresa(string empresaId, CancellationToken cancellationToken)
    {
        return await _context.Cadastro
            .AsNoTracking()            
            .ToListAsync(cancellationToken);        
    }

    public async Task<Cadastro?> ObterCadastroPorNumeroPatrimonial(decimal numeroPatrimonial, CancellationToken cancellationToken)
    {
        var cadastro = await _context.Cadastro
            .AsNoTracking()
            .Where(c => c.NumeroPatrimonial == numeroPatrimonial)
            .ToListAsync(cancellationToken);

        return cadastro.FirstOrDefault();
    }
}
