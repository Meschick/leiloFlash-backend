using leiloFlash_backend.DTO.MercadoPago;
using leiloFlash_backend.Repositories.Lote;
using MercadoPago;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;

namespace leiloFlash_backend.Services.Pagamento
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoteRepository _loteRepository;

        public PagamentoService(IConfiguration configuration, ILoteRepository loteRepository)
        {
            _configuration = configuration;
            _loteRepository = loteRepository;
            MercadoPagoConfig.AccessToken = _configuration["MercadoPago:AccessToken"];
        }

        public async Task<MercadoPagoPreferenceResponseDTO> CriarPreferenciaPagamento(int loteId)
        {
            var lote = await _loteRepository.GetByIdAsync(loteId);

            if (lote is null) throw new Exception("Lote não encontrado.");

            var cliente = new PreferenceClient();

            var preferenceRequest = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Title = $"Lote {lote.NumeroLote} - Leilão {lote.LeilaoId}",
                        Quantity = 1,
                        UnitPrice = Convert.ToDecimal(lote.ValorFinal)
                    }
                },
                Payer = new PreferencePayerRequest
                {
                    Email = "test_user_123@test.com"
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "https://seusite.com/sucesso",
                    Failure = "https://seusite.com/falha",
                    Pending = "https://seusite.com/pendente"
                },
                AutoReturn = "approved"
            };

            var preference = await cliente.CreateAsync(preferenceRequest);

            return new MercadoPagoPreferenceResponseDTO
            {
                InitPoint = preference.InitPoint,
                PreferenceId = preference.Id
            };
        }
    }
}
