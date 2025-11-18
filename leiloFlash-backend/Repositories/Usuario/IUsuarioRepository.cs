using leiloFlash_backend.Models;

namespace leiloFlash_backend.Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> GetUserByIdAsync(int id);
    }
}
