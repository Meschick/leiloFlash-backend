using leiloFlash_backend.Data;
using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LeiloDbContext _context;

        public UsuarioRepository(LeiloDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> GetUserByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
