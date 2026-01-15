using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioCiclico.API.Domain.Entities;

[Table("CADASTRO")]
public class Cadastro
{
    [Column("EMPRESAID")]
    public string EmpresaId { get; set; }

    [Column("EMPRESAFILIALID")]
    public string EmpresaFilialId { get; set; }
    public string FabricaId { get; set; }
    public string PlantaDeSeguroId { get; set; }
    public string CentroDeCustoId { get; set; }
    public string DepartamentoId { get; set; }
    
    [Column("NUMEROPATRIMONIAL")]
    public decimal NumeroPatrimonial { get; set; }

    [Column("TIPOINCORPORACAOID")]
    public int TipoIncorporacaoId { get; set; }

    [Column("INCORPORACAO")]
    public int Incorporacao { get; set; }

    [Column("DATAAQUISICAO")]
    public DateTime DataAquisicao { get; set; }

    [Column("VALORAQUISICAO")]
    public decimal ValorAquisicao { get; set; }

    [Column("DESCRICAORESUMIDA")]
    public string DescricaoResumida { get; set; }

    [Column("DESCRICAODETALHADA")]
    public string DescricaoDetalhada { get; set; }

    [Column("CONTAID")]
    public string ContaId { get; set; }
    public int Quantidade { get; set; }
    public string Modelo { get; set; }
    public string Tipo { get; set; }
    public string Serie { get; set; }
    public string FornecedorId { get; set; }
    public string Documento { get; set; }
    public string Estrangeiro { get; set; }
    public int StatusBemId { get; set; }
    public int EstadoBemId { get; set; }
    public DateTime? VencimentoGarantia { get; set; }

    [Column("VALORATUALIZADO")]
    public decimal ValorAtualizado { get; set; }
    public decimal DepreciacaoAcumulada { get; set; }
    public decimal ValorResidual { get; set; }
    public decimal ValorAtualizadoDollar { get; set; }
    public decimal DepreciacaoAcumuladaDollar { get; set; }
    public decimal ValorResidualDollar { get; set; }
    public decimal TaxaDepreciacao { get; set; }
    public decimal TaxaDepreciacaoDollar { get; set; }
    public DateTime InicioDepreciacao { get; set; }
    public DateTime InicioDepreciacaoDollar { get; set; }
    public int? ResponsavelId { get; set; }
    public int? TipoBemId { get; set; }
    public int? Pi { get; set; }
    public string NumeroPatrimonialAnterior { get; set; }
    public decimal DepreciacaoAcumuladaUfir { get; set; }
    public decimal ValorAtualUfir { get; set; }
    public string Observacao { get; set; }
    public string Controle { get; set; }
    public decimal DepreciacaoAnterior { get; set; }
    public decimal DepreciacaoDollarAnterior { get; set; }
    public decimal TaxaDepreciacaoGerencial { get; set; }
    public decimal ValorAtualizadoGerencial { get; set; }
    public decimal DepreciacaoAcumuladaGerencial { get; set; }
    public decimal ValorResidualGerencial { get; set; }
    public decimal DepreciacaoGerencialAnterior { get; set; }
    public string DocumentoSerie { get; set; }
    public int ClasseId { get; set; }
    public int? Ncm { get; set; }
    public string Nfe { get; set; }
    public string Campo1 { get; set; }
    public string Campo2 { get; set; }
    public string Campo3 { get; set; }
    public string Campo4 { get; set; }
    public string Campo5 { get; set; }
    public string Campo6 { get; set; }
    public int ProdutoId { get; set; }
    public DateTime? DataBloqueio { get; set; }
    public long NcdPatrimonio { get; set; }
    public string CcdBarra { get; set; }
    public long? Master { get; set; }
    public int MemorialId { get; set; }
    public long NumeroPatrimonialObra { get; set; }
    public string DescricaoObra { get; set; }
    public decimal ValorNfTransf { get; set; }
    public int QtdCotas { get; set; }
    public decimal ValorCota { get; set; }
    public string Classificacao { get; set; }
    public string Rateio { get; set; }
    public decimal PercentualCusto { get; set; }
    public decimal PercentualDep { get; set; }
    public decimal NovoValor { get; set; }
    public decimal NovoDep { get; set; }
    public decimal TotalValor { get; set; }
    public decimal TotalDep { get; set; }
    public decimal ResidualVenda { get; set; }
    public string ObraParcial { get; set; }
    public decimal? CreditoPis { get; set; }
    public decimal? CreditoCofins { get; set; }
    public decimal? CreditoIcmDestacado { get; set; }
    public string CodigoAneel { get; set; }
    public string DocumentoOrigem1 { get; set; }
    public string ItemDocumentoOrigem1 { get; set; }
    public int? Cfop { get; set; }
    public decimal? TotalNf { get; set; }
}
