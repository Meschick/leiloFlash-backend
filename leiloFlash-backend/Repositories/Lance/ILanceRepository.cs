using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories.Lance
{
    public interface ILanceRepository
    {
        Task AdicionarLanceAsync(LanceModel lance);
        Task SalvarAsync();
    }
}
