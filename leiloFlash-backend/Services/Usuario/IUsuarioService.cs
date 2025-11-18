using leiloFlash_backend.DTO.Usuario;

namespace leiloFlash_backend.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseDTO> ObterUsuarioPorId(int id);
    }
}
