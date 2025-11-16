using leiloFlash_backend.Data;
using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Repositories.Lote
{
    public class LoteRepository : ILoteRepository
    {
        private readonly LeiloDbContext _context;

        public LoteRepository(LeiloDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LoteModel>> GetAllAsync()
        {
            return await _context.Lote
                .Include(l => l.Usuario)
                .Include(l => l.Veiculo)
                .Include(l => l.Leilao)
                .ToListAsync();
        }

        public async Task<LoteModel?> GetByIdAsync(int id)
        {
            return await _context.Lote
                .Include(l => l.Usuario)
                .Include(l => l.Veiculo)
                .ThenInclude(v => v.Imagens)
                .Include(l => l.Leilao)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    
        public async Task CreateAsync(LoteModel lote)
        {
            _context.Lote.Add(lote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoteModel lote)
        {
            _context.Lote.Update(lote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lote = await _context.Lote.FindAsync(id);
            if (lote != null)
            {
                _context.Lote.Remove(lote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
