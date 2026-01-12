using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace InventarioCiclico.API.Application.Dtos;

public class InsereEmpresaDto
{
    public string EmpresaId { get; set; }
    public string RazaoSocial { get; set; }
    public string CGC { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Usuario { get; set; }
}
