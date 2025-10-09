using leiloFlash_backend.Models;

namespace leiloFlash_backend.Services.Auth.Security
{
    public interface ITokenService
    {
        string GerarToken(UsuarioModel usuario);
    }
}
