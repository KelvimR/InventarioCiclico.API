namespace InventarioCiclico.API.Exceptions;

public class BusinessException : AppException
{
    // Regras de negócio
    public BusinessException(string message) : base(message)
    {        
    }
}
