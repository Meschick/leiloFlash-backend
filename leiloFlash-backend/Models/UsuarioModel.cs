using leiloFlash_backend.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
    public class UsuarioModel
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }


        [Required( ErrorMessage = "O email é obrigatório")]
        [Column("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [MaxLength(255)]
        [Column("senha")]
        public string Senha { get; set; }

        [Column("tipo")]
        public TipoUsuarioEnum? Tipo { get; set; }

        [Column("cpf")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "É obrigatório ter 11 caracteres " )]
        public string? Cpf { get; set; }

        [Column("telefone")]
        public string? Telefone { get; set; }

        [Column("data_cadastro")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        [Column("status_usuario")]
        public StatusEnum? StatusUsuario { get; set; } = StatusEnum.Ativo;

        [ForeignKey("Endereco")]
        [Column("endereco_id")]
        public int? EnderecoId { get; set; }
        public EnderecoModel? Endereco { get; set; }

        public UsuarioModel() { }


    }

       
}
