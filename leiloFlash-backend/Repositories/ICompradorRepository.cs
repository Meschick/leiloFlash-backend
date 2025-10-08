using leiloFlash_backend.DTO;
using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories
{
    public interface ICompradorRepository
    {
        Task CreateComprador(CompradorModel comprador);
    }
}
