namespace leiloFlash_backend.DTO.Response
{
    public class ApiResponseDTO<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public T? Data { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public ApiResponseDTO() { }

        public ApiResponseDTO(bool sucesso, string mensagem, T? data = default)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

    }
}
