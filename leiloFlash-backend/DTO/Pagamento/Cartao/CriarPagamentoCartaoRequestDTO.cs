namespace leiloFlash_backend.DTO.Pagamento.Cartao
{
    public class CriarPagamentoCartaoRequestDTO
    {
        public int LoteId { get; set; }
        public decimal Valor { get; set; }

        public string Token { get; set; }
        public string PaymentMethodId { get; set; }
        public int Installments { get; set; }
        public string IssuerId { get; set; }

        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }

        public string Email { get; set; }
    }
}
