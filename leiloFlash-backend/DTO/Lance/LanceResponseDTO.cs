namespace leiloFlash_backend.DTO.Lance
{
    public class LanceResponseDTO
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }

        public int LoteId { get; set; }
        public int UsuarioId { get; set; }
    }
}
