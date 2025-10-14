using leiloFlash_backend.DTO.Usuario;

namespace leiloFlash_backend.Services.Auth
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string email, string senha);
        Task<bool> RegistrarUsuario(UsuarioDTO usuario);
    }
}
