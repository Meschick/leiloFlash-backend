using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leiloFlash_backend.Models
{
    public class UsuarioModel
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required( ErrorMessage = "O email é obrigatório")]
        [Column("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 a 8 caracteres.")]
        [Column("senha")]
        public string Senha { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }


        public UsuarioModel() { }
    }

       
}
