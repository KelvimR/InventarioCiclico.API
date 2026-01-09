using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioCiclico.API.Domain.Entities;

[Table("EMPRESAS", Schema ="JBS")]
public class Empresa
{
    [Key]
    [Required]
    [Column("EMPRESAID")]
    public string EmpresaId { get; set; }
    
    [Required]
    [Column("RAZAOSOCIAL")]
    public string RazaoSocial { get; set; }
    [Column("CGC")]
    public string CGC { get; set; }
    [Column("ENDERECO")]
    public string Endereco { get; set; }

    [Column("TELEFONE")]
    public string Telefone { get; set; }
}
