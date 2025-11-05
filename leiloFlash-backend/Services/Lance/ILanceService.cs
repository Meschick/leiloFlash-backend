using leiloFlash_backend.DTO.Lance;

namespace leiloFlash_backend.Services.Lance
{
    public interface ILanceService
    {
        Task<LanceResponseDTO> DarLanceAsync(LanceRequestDTO request);
    }
}
