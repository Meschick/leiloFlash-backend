namespace leiloFlash_backend.DTO.Pagamento
{
    public class CriarPagamentoRequestDTO
    {
        public int LoteId { get; set; }
        public decimal Valor { get; set; }

        public string Metodo { get; set; }

        public string Token { get; set; }
        public string PaymentMethodId { get; set; }
        public int? Installments { get; set; }
    }
}
