using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
    public class VeiculoModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("ano")]
        public int Ano { get; set; }

        [Column("cor")]
        public string Cor { get; set; }

        [Column("km_atual")]
        public decimal kmAtual { get; set; }

        [Column("valor_inicial")]
        public decimal ValorInicial { get; set; }

        public ICollection<ImagemModel> Imagens { get; set; }
    }
}
