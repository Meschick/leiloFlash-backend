namespace leiloFlash_backend.DTO.Pagamento
{
    public class CriarPagamentoResponseDTO
    {
        public string Status { get; set; }

        public string QrCodeBase64 { get; set; }
        public string QrCode { get; set; }

        public string InitPointCard { get; set; }

        public string PaymentId { get; set; }
    }
}
