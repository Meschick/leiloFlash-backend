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
