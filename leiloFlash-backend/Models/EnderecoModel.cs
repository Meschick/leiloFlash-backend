using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
    public class EnderecoModel
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório")]
        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }


        [Required(ErrorMessage = "O bairro é obrigatório")]
        [Column("bairro")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "A cidade é obrigatória")]
        [Column("cidade")]
        public string Cidade { get; set; }

    }
}
