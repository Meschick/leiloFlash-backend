using leiloFlash_backend.Data;
using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Repositories.Lance
{
    public class LanceRepository : ILanceRepository
    {
        private readonly LeiloDbContext _context;

        public LanceRepository(LeiloDbContext context) 
        { 
            _context = context;
        }

        public async Task<LanceModel?> GetUltimoLancePorLoteId(int loteId)
        {
            return await _context.Lance
                .Where(l => l.LoteId == loteId)
                .Include(u => u.Usuario)
                .OrderByDescending(l => l.DataHora)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LanceModel>> GetHistoryByLoteIdAsync(int id)
        {
            return await _context.Lance
                .Where(l => l.LoteId == id)
                .Include(u => u.Usuario)
                .OrderByDescending(l => l.DataHora)
                .Take(5)
                .ToListAsync();
        }

        public async Task AdicionarLanceAsync(LanceModel lance)
        {
            await _context.Lance.AddAsync(lance);
        }

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
