using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
    public class CompradorModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required( ErrorMessage = "O nome é obrigatório")]
        [Column("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [Column("email")]
        public string Email { get; set; }


        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [Column("cpf")]
        public string Cpf { get; set; }

      
        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Column("telefone")]
        public string Telefone { get; set; }


        [Required]
        [ForeignKey("EnderecoId")]
        public EnderecoModel Endereco { get; set; }

        [Required]
        [Column("endereco_id")]
        public int EnderecoId { get; set; }

        [Required]
        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }



    }
}
