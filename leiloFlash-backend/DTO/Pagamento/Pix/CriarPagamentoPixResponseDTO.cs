namespace leiloFlash_backend.DTO.Pagamento.Pix
{
    public class CriarPagamentoPixResponseDTO
    {
        public string Status { get; set; }
        public string QrCodeBase64 { get; set; }
        public string QrCode { get; set; }
        public string PaymentId { get; set; }
    }
}
