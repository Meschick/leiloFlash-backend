using leiloFlash_backend.Data;
using leiloFlash_backend.Services.Auth.Security;

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
             var user = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if(user == null) return null;

            if (!_senhaService.VerificarSenha(senha, user.Senha)) return null;

            return _tokenService.GerarToken(user);
        }
    }
}
