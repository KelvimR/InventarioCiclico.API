namespace InventarioCiclico.API.Exceptions;

public class ValidationException : AppException
{
    // Para dados inválidos
    public IReadOnlyCollection<string> Errors { get; }

    public ValidationException(IEnumerable<string> errors)
        : base("Erro de validação")
    {
        Errors = errors.ToList();
    }
}
