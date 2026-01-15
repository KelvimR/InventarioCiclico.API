using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioCiclico.API.Application.Dtos;

public class ConsultaCadastroDto
{
    public string EmpresaId { get; set; }
    public string EmpresaFilialId { get; set; }
    public string CentroDeCustoId { get; set; }
    public decimal NumeroPatrimonial { get; set; }
    public int TipoIncorporacaoId { get; set; }
    public int Incorporacao { get; set; }
    public DateTime DataAquisicao { get; set; }
    public decimal ValorAquisicao { get; set; }
    public string DescricaoResumida { get; set; }
    public string ContaId { get; set; }
    public decimal ValorAtualizado { get; set; }
    public decimal DepreciacaoAcumulada { get; set; }
    public decimal ValorResidual { get; set; }
    public int ClasseId { get; set; }

    // Criar link com contas e classes
    
}
