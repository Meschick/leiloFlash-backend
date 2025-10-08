using leiloFlash_backend.Models;

namespace leiloFlash_backend.DTO
{
    public class CompradorDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public int UsuarioId { get; set; }
    }
}
