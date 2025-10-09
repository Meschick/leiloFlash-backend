namespace leiloFlash_backend.Services.Auth.Security
{
    public interface ISenhaService
    {
        bool VerificarSenha(string senha, string hash);
        string HashSenha(string senha);
    }
}
