namespace leiloFlash_backend.Services.Auth
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string email, string senha);
    }
}
