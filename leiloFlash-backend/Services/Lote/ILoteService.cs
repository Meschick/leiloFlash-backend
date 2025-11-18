using leiloFlash_backend.DTO.Lote;

namespace leiloFlash_backend.Services.Lote
{
    public interface ILoteService
    {
        Task<IEnumerable<LotesArrematadosResponseDTO>> ObterLotesArramatados(int usuarioId);
        Task<FinalizarLoteResponseDTO> FinalizarLote(int loteId);
        Task<LoteResponseDTO> ObterLotePorId(int id);
    }
}
