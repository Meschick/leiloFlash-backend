using leiloFlash_backend.DTO.Lote;
using leiloFlash_backend.DTO.Usuario;

namespace leiloFlash_backend.DTO.Leilao
{
    public class LeilaoResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string StatusLeilao { get; set; }

        public UsuarioResponseDTO Usuario { get; set; }
        public List<LoteResponseDTO> Lotes { get; set; }
    }
}
