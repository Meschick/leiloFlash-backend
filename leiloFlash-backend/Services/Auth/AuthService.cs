using leiloFlash_backend.Data;
using leiloFlash_backend.Services.Auth.Token;

namespace leiloFlash_backend.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly LeiloDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(LeiloDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string?> LoginAsync(string email, string senha)
        {
             var user = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if(user == null) return null;

            if (user.Senha != senha) return null;

            return _tokenService.GenerateToken(user);
        }
    }
}
