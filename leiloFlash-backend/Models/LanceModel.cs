using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
    [Table("Lance")]
    public class LanceModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("data_hora")]
        public DateTime DataHora { get; set; } = DateTime.Now;

        [ForeignKey("Lote")]
        [Column("lote_id")]
        public int? LoteId { get; set; }
        public LoteModel? Lote { get; set; }

        [ForeignKey("Usuario")]
        [Column("usuario_id")]
        public int? UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
