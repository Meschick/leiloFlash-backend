using leiloFlash_backend.DTO.MercadoPago;

namespace leiloFlash_backend.Services.Pagamento
{
    public interface IPagamentoService
    {
        Task<MercadoPagoPreferenceResponseDTO> CriarPreferenciaPagamento(int loteId);
    }
}
