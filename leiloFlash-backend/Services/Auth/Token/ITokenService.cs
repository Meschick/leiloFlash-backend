using leiloFlash_backend.Models;

namespace leiloFlash_backend.Services.Auth.Token
{
    public interface ITokenService
    {
        string GerarToken(UsuarioModel usuario);
    }
}
