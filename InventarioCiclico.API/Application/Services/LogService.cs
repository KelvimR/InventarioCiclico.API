using InventarioCiclico.API.Application.Dtos;
using InventarioCiclico.API.Application.Interfaces.Repositories;
using InventarioCiclico.API.Application.Interfaces.Services;
using InventarioCiclico.API.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace InventarioCiclico.API.Application.Services;

public class LogService : ILogService
{
    private readonly ILogRepository _repository;
    public LogService(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task InserirLogAsync(Log log, CancellationToken cancellationToken)
    {
        if (log == null)
            throw new ValidationException("Dados do log não podem ser nulos.");

        if (string.IsNullOrWhiteSpace(log.EmpresaId))
            throw new ValidationException("Empresa é obrigatório.");

        if (string.IsNullOrWhiteSpace(log.Operacao))
            throw new ValidationException("Não foi informado a descrição da operação.");

        if (string.IsNullOrWhiteSpace(log.Usuario))
            throw new ValidationException("Não foi informado o usuário da operação.");
        
        await _repository.InserirLogAsync(log, cancellationToken);
    }

}
