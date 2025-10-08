using leiloFlash_backend.Data;
using leiloFlash_backend.DTO;
using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories
{
    public class CompradorRepository : ICompradorRepository
    {

        private readonly LeiloDbContext _leiloDbContext;


        public CompradorRepository(LeiloDbContext leiloDbContext)
        {
            _leiloDbContext = leiloDbContext;
        }

        public async Task CreateComprador(CompradorModel comprador)
        {
            await _leiloDbContext.AddAsync(comprador);
            await _leiloDbContext.SaveChangesAsync();   
        }
    }
}
