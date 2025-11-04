using leiloFlash_backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
    [Table("Leilao")]
    public class LeilaoModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime DataFim { get; set; }

        [Column("status_leilao")]
        public StatusLeilaoEnum StatusLeilao { get; set; }

        [ForeignKey(nameof(Usuario))]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
        public virtual ICollection<LoteModel> Lotes { get; set; } = new List<LoteModel>();
    }
}
