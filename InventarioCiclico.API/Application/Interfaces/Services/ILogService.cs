using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Domain.Entities;

namespace InventarioCiclico.API.Application.Interfaces.Services;

public interface ILogService
{
    Task InserirLogAsync(Log log, CancellationToken cancellationToken);
}
