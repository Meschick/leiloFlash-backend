using leiloFlash_backend.Data;
using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories.Veiculo
{
    public class VeiculoRepository: IVeiculoRepository
    {
        private readonly LeiloDbContext _context;

        public VeiculoRepository(LeiloDbContext context)
        {
            _context = context;
        }


        public async Task<VeiculoModel> GetById(int id)
        {
            return await _context.Veiculo.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<VeiculoModel> GetAllAsync()
        {
            return await _context.Veiculo.FirstOrDefaultAsync().toList();
        }

    }
}
