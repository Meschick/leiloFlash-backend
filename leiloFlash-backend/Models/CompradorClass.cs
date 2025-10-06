using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace leiloFlash_backend.Models
{
    public class CompradorClass
    {


        [Key]
        public int Id { get; set; }

        [Required( ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }

    }
}
