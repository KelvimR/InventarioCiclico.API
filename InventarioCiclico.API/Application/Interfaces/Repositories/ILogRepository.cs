using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Domain.Entities;
using InventarioCiclico.API.Infrastructure.Persistence;

namespace InventarioCiclico.API.Application.Interfaces.Repositories;

public interface ILogRepository
{
    Task InserirLogAsync(Log log, CancellationToken cancellationToken);
}
