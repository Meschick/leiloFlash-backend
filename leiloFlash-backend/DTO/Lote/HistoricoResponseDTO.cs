using leiloFlash_backend.Models;

namespace leiloFlash_backend.DTO.Lote
{
    public class HistoricoResponseDTO
    {
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }

        public int UsuarioId { get; set; }

        public string EmailUsuario { get; set; }

    }
}
