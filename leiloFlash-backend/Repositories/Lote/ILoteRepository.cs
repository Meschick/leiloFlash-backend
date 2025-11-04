using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories.Lote
{
    public interface ILoteRepository
    {
        Task<LoteModel> GetByIdAsync(int id);
        Task<IEnumerable<LoteModel>> GetAllAsync();
        Task CreateAsync(LoteModel lote);
        Task UpdateAsync(LoteModel lote);
        Task DeleteAsync(int id);
    }
}
