using leiloFlash_backend.Data;
using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Repositories.Leilao
{
    public class LeilaoRepository : ILeilaoRepository
    {

        private readonly LeiloDbContext _context;

        public LeilaoRepository(LeiloDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(LeilaoModel leilao)
        {
            _context.Leiloes.Add(leilao);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteLeilaoAsync(int id)
        {
            var leilao = await GetByIdAsync(id);
            if (leilao == null) return false;

            _context.Leiloes.Remove(leilao);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<LeilaoModel>> GetAllAsync()
        {
           return await _context.Leiloes.ToListAsync();

        }

        public async Task<LeilaoModel> GetByIdAsync(int id)
        {
            return await _context.Leiloes.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateAsync(LeilaoModel leilao)
        {
            _context.Leiloes.Update(leilao);
            await _context.SaveChangesAsync();
        }
    }
}
