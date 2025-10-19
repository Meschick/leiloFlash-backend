using leiloFlash_backend.Models;

namespace leiloFlash_backend.DTO.Leilao
{
    public class LeilaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int UsuarioId { get; set; }
    }
}
