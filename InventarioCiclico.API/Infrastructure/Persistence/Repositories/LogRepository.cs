using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventarioCiclico.API.Infrastructure.Persistence.Repositories;

public class LogRepository : ILogRepository
{
    private readonly AppDbContext _context;

    public LogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task InserirLogAsync(Log log, CancellationToken cancellationToken)
    {
        var sequencia = await _context.Database
            .SqlQueryRaw<long>("SELECT SEQ_PATRIMONIO_LOG.NEXTVAL FROM DUAL")
            .SingleAsync(cancellationToken);

        log.Sequencia = sequencia;

        _context.Log.Add(log);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
