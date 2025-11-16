using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
    [Table("Lote")]
    public class LoteModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("numero_lote")]
        public int NumeroLote { get; set; }

        [Column("valor_inicial")]
        public decimal ValorInicial { get; set; }

        [Column("valor_atual")]
        public decimal? ValorAtual { get; set; }

        [Column("valor_final")]
        public decimal? ValorFinal { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("tipo_retomada")]
        public string TipoRetomado { get; set; }

        [Column("valor_mercado")]
        public decimal ValorMercado { get; set; }

        [Column("localizacao")]
        public string Localizacao { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [ForeignKey("Leilao")]
        [Column("leilao_id")]
        public int? LeilaoId { get; set; }
        public LeilaoModel? Leilao { get; set; }

        [ForeignKey("Veiculo")]
        [Column("veiculo_id")]
        public int? VeiculoId { get; set; }
        public VeiculoModel? Veiculo { get; set; }

        [ForeignKey("Usuario")]
        [Column("usuario_id")]
        public int? UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }

        [ForeignKey("UltimoLanceUsuario")]
        [Column("ultimo_lance_usuario_id")]
        public int? UltimoLanceUsuarioId { get; set; }
        public UsuarioModel? UltimoLanceUsuario { get; set; }
    }
}
