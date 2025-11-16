namespace leiloFlash_backend.DTO.Lote
{
    public class FinalizarLoteResponseDTO
    {
        public int? UsuarioVencedorId { get; set; }

        public string EmailUsuarioVencedor { get; set; }
        public decimal? ValorFinal { get; set; }
    }
}
