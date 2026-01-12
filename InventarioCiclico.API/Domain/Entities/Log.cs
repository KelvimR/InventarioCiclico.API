using System;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventarioCiclico.API.Domain.Entities;

[Table("LOG")]
public class Log
{
    [Column("SEQUENCIA")]
    public long Sequencia { get; set; }

    [Column("DATA")]
    public DateTime Data { get; set; }
    
    [Column("OPERACAO")]
    public string Operacao { get; set; }

    [Column("USUARIO")]
    public string Usuario { get; set; }

    [Column("EMPRESAID")]
    public string EmpresaId { get; set; }
    
}
