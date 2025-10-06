using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace leiloFlash_backend.Models
{
    public class CompradorModel
    {
        [Key]
        public int Id { get; set; }

        [Required( ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }           
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required]
        public EnderecoModel Endereco { get; set; }

        [Required]
        public int EnderecoId { get; set; }


    }
}
