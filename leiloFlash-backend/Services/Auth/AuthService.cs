using leiloFlash_backend.Data;
using leiloFlash_backend.DTO.Response;
using leiloFlash_backend.DTO.Usuario;
using leiloFlash_backend.Models;
using leiloFlash_backend.Services.Auth.Security;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly LeiloDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly ISenhaService _senhaService;

        public AuthService(LeiloDbContext context, ITokenService tokenService, ISenhaService senhaService)
        {
            _context = context;
            _tokenService = tokenService;
            _senhaService = senhaService;
        }

        public async Task<string?> LoginAsync(string email, string senha)
        {
             var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if(user == null) return null;

            if (!_senhaService.VerificarSenha(senha, user.Senha)) return null;

            return _tokenService.GerarToken(user);
        }

        public async Task<bool> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuarioDTO.Email);

            if(usuarioExistente is null)
            {
                var novoUsuario = new UsuarioModel
                {
                    Email = usuarioDTO.Email,
                    Senha = _senhaService.HashSenha(usuarioDTO.Senha),
                    Tipo = Enums.TipoUsuarioEnum.Usuario,
                    StatusUsuario = Enums.StatusEnum.Ativo
                };

                _context.Usuarios.Add(novoUsuario);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
