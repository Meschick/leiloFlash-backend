using leiloFlash_backend.Data;
using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Repositories.Veiculo
{
    public class VeiculoRepository: IVeiculoRepository
    {
        private readonly LeiloDbContext _context;

        public VeiculoRepository(LeiloDbContext context)
        {
            _context = context;
        }

         public async Task<List<VeiculoModel>> GetAllAsync()
        {
            return await _context.Veiculo.ToListAsync();
        }

        public async Task<VeiculoModel> GetByIdAsync(int id)
        {
            return await _context.Veiculo.FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
