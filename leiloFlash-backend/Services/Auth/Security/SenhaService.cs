using Microsoft.AspNetCore.Identity;

namespace leiloFlash_backend.Services.Auth.Security
{

    public class SenhaService : ISenhaService
    {
        private readonly PasswordHasher<object> _hasher = new PasswordHasher<object>();

        
        public string HashSenha(string senha)
        {
            return _hasher.HashPassword(null, senha);
        }

        public bool VerificarSenha(string senha, string hash)
        {
            var result = _hasher.VerifyHashedPassword(null, hash, senha);
            return result == PasswordVerificationResult.Success;
        }
    }
}
