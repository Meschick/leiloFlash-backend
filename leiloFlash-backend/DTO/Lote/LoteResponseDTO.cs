using leiloFlash_backend.DTO.Usuario;
using leiloFlash_backend.DTO.Veiculo;
using leiloFlash_backend.Models;

namespace leiloFlash_backend.DTO.Lote
{
    public class LoteResponseDTO
    {

        public int Id { get; set; }
        public int NumeroLote { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal? ValorFinal { get; set; }

        public int? LeilaoId { get; set; }
        public int? UsuarioId { get; set; }

        public VeiculoResponseDTO? Veiculo { get; set; }
        public UsuarioResponseDTO? Usuario { get; set; }
    }
}
