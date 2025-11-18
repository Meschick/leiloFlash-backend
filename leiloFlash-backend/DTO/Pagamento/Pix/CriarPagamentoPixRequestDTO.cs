namespace leiloFlash_backend.DTO.Pagamento.Pix
{
    public class CriarPagamentoPixRequestDTO
    {
        public int LoteId { get; set; }
        public decimal Valor { get; set; }
    }
}
