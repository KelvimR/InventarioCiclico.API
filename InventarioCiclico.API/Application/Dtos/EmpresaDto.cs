namespace InventarioCiclico.API.Application.Dtos;

public class EmpresaDto
{
    /// <example>001<example>
    public string EmpresaId { get; set; }
    
    /// <example>Empresa zero companhia LTDA<example>
    public string RazaoSocial { get; set; }

    /// <example>23309988000180<example>
    public string CGC { get; set; }

    /// <example>Av. Imperatriz Leopoldina</example>
    public string Endereco { get; set; }

    /// <example>(11) 99999-9999</example>
    public string Telefone { get; set; }
}
