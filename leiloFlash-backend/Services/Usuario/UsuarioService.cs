using AutoMapper;
using leiloFlash_backend.DTO.Usuario;
using leiloFlash_backend.Repositories.Usuario;

namespace leiloFlash_backend.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioResponseDTO> ObterUsuarioPorId(int id)
        {
            var usuario= await _usuarioRepository.GetUserByIdAsync(id);

            if (usuario is null) throw new Exception("Usuário não encontrado");

            return _mapper.Map<UsuarioResponseDTO>(usuario);
        }
    }
}
