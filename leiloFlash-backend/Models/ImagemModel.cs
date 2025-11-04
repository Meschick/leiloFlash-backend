using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{

    [Table("Imagem")]
    public class ImagemModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("data_upload")]
        public DateTime DataUpload { get; set; }

        [Column("veiculo_id")]
        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }

        public VeiculoModel Veiculo { get; set; }
    }
}
