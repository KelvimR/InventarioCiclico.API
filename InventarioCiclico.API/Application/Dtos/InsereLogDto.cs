using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioCiclico.API.Application.Dtos;

public class InsereLogDto
{
    public DateTime Data { get; set; }
    public string Operacao { get; set; }
    public string Usuario { get; set; }
    public string EmpresaId { get; set; }

}
