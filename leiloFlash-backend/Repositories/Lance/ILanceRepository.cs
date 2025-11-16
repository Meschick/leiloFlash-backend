using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories.Lance
{
    public interface ILanceRepository
    {
        Task<IEnumerable<LanceModel>> GetHistoryByLoteIdAsync(int id);
        Task<LanceModel> GetUltimoLancePorLoteId(int loteId);
        Task AdicionarLanceAsync(LanceModel lance);
        Task SalvarAsync();
    }
}
