using leiloFlash_backend.DTO.Leilao;
using leiloFlash_backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
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

        [ForeignKey("Usuario")]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        public LeilaoModel() { }

        public LeilaoModel(LeilaoDTO leilaoDto)
        {
            Nome = leilaoDto.Nome;
            Descricao = leilaoDto.Descricao;
            DataInicio = leilaoDto.DataInicio;
            DataFim = leilaoDto.DataFim;
            UsuarioId = leilaoDto.UsuarioId;
        }
    }
}
