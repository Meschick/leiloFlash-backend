using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories.Veiculo
{
    public interface IVeiculoRepository
    {
        Task<List<VeiculoModel>> GetAllAsync();
        Task<VeiculoModel> GetByIdAsync(int id);

    }
}
