using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioCiclico.API.Domain.Entities;

[Table("Empresas")]
public class Empresa
{
    [Key]
    [Required]
    public int EmpresaId { get; set; }
    
    [Required]
    public string RazaoSocial { get; set; }
    
    public string CGC { get; set; }
    
    public string Endereco { get; set; }
    
    public string Telefone { get; set; }
}
