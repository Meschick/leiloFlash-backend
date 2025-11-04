namespace leiloFlash_backend.DTO.Lote
{
    public class LoteDTO
    {
        public int NumeroLote { get; set; }
        public decimal ValorInicial { get; set; }
        public int LeilaoId { get; set; }
        public int VeiculoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
