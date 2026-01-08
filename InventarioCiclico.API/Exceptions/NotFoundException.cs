namespace InventarioCiclico.API.Exceptions;

public class NotFoundException : AppException
{
    //Para entidade não encontrada
    // ex throw new NotFoundException("Empresa", id);

    public NotFoundException(string entity, Object key)
        : base($"{entity} não encontrado. ({key})")
    {        
    }
}
