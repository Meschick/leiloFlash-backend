using System.ComponentModel.DataAnnotations;

namespace leiloFlash_backend.Models
{
    public class EnderecoModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }  
        public string Complemento { get; set; }


        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

    }
}
