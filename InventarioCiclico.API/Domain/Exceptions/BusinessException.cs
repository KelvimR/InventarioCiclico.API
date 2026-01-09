using InventarioCiclico.API.Exceptions;

namespace InventarioCiclico.API.Domain.Exceptions;

public class BusinessException : AppException
{
    // Regras de negócio
    public BusinessException(string message) : base(message)
    {        
    }
}
