using leiloFlash_backend.DTO.MercadoPago;
using leiloFlash_backend.DTO.Pagamento;
using leiloFlash_backend.DTO.Pagamento.Cartao;
using leiloFlash_backend.DTO.Pagamento.Pix;

namespace leiloFlash_backend.Services.Pagamento
{
    public interface IPagamentoService
    {
        Task<string> CriarPreferenciaPagamentoCartao(CriarPreferenciaRequestDTO request);
        Task<CriarPagamentoPixResponseDTO> CriarPagamentoPix(CriarPagamentoPixRequestDTO request);
        Task<CriarPagamentoCartaoResponseDTO> CriarPagamentoCartao(CriarPagamentoCartaoRequestDTO request);
    }
}
