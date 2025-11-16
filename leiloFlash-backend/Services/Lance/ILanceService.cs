using leiloFlash_backend.DTO.Lance;
using leiloFlash_backend.DTO.Lote;

namespace leiloFlash_backend.Services.Lance
{
    public interface ILanceService
    {
        Task<IEnumerable<HistoricoResponseDTO>> HistoricoPorLote(int loteId);
        Task<LanceResponseDTO> DarLanceAsync(LanceRequestDTO request);
    }
}
