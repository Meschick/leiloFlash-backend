using leiloFlash_backend.DTO;
using leiloFlash_backend.Models;

namespace leiloFlash_backend.Services
{
    public interface ICompradorService
    {
        Task CreateComprador(CompradorDTO comprador);
    }
}
