using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories.Leilao
{
    public interface ILeilaoRepository
    {
        Task CreateAsync(LeilaoModel leilao);
        Task<List<LeilaoModel>> GetAllAsync();
        Task<LeilaoModel> GetByIdAsync(int id);
        Task UpdateAsync(LeilaoModel leilao);
        Task<bool> DeleteLeilaoAsync(int id);
    }
}
