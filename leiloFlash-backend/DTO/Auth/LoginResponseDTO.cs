namespace leiloFlash_backend.DTO.Auth
{
    public class LoginResponseDTO
    {

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    }
}
