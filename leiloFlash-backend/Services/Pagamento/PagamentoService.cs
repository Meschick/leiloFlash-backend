using leiloFlash_backend.DTO.MercadoPago;
using leiloFlash_backend.DTO.Pagamento;
using leiloFlash_backend.DTO.Pagamento.Cartao;
using leiloFlash_backend.DTO.Pagamento.Pix;
using leiloFlash_backend.Repositories.Lote;
using MercadoPago;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
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

        public async Task<CriarPagamentoPixResponseDTO> CriarPagamentoPix(CriarPagamentoPixRequestDTO request)
        {
            var lote = await _loteRepository.GetByIdAsync(request.LoteId);
            if (lote == null)
                throw new Exception("Lote não encontrado.");

            var paymentClient = new PaymentClient();

            var paymentRequest = new PaymentCreateRequest
            {
                TransactionAmount = request.Valor,
                Description = $"Pagamento PIX do lote Nº {lote.NumeroLote}",
                PaymentMethodId = "pix",

                     Payer = new PaymentPayerRequest
                     {
                         Email = "teste@teste.com"
                     }
            };

            Payment payment = await paymentClient.CreateAsync(paymentRequest);

            return new CriarPagamentoPixResponseDTO
            {
                Status = payment.Status,
                PaymentId = payment.Id.ToString(),
                QrCodeBase64 = payment.PointOfInteraction?.TransactionData?.QrCodeBase64,
                QrCode = payment.PointOfInteraction?.TransactionData?.QrCode
            };
        }


        public async Task<CriarPagamentoCartaoResponseDTO> CriarPagamentoCartao(CriarPagamentoCartaoRequestDTO request)
        {
            var lote = await _loteRepository.GetByIdAsync(request.LoteId);
            if (lote == null)
                throw new Exception("Lote não encontrado.");

            var paymentClient = new PaymentClient();

            var paymentRequest = new PaymentCreateRequest
            {
                TransactionAmount = request.Valor,
                Description = $"Pagamento com cartão — lote Nº {lote.NumeroLote}",
                Token = request.Token,
                PaymentMethodId = request.PaymentMethodId,
                Installments = request.Installments,
                IssuerId = request.IssuerId,
                Payer = new PaymentPayerRequest
                {
                    Email = request.Email,
                    Identification = new IdentificationRequest
                    {
                        Type = request.IdentificationType,
                        Number = request.IdentificationNumber
                    }
                }
            };

            Payment payment = await paymentClient.CreateAsync(paymentRequest);

            return new CriarPagamentoCartaoResponseDTO
            {
                Status = payment.Status,
                PaymentId = payment.Id.ToString()
            };
        }


        public async Task<string> CriarPreferenciaPagamentoCartao(CriarPreferenciaRequestDTO request)
        {
            var lote = await _loteRepository.GetByIdAsync(request.LoteId);
            if (lote == null)
                throw new Exception("Lote não encontrado.");

      
            var item = new PreferenceItemRequest
            {
                Title = $"Pagamento Lote Nº {lote.NumeroLote}",
                Description = "Pagamento com cartão de crédito/débito.",
                Quantity = 1,
                CurrencyId = "BRL",
                UnitPrice = request.Valor
            };

            var payer = new PreferencePayerRequest
            {
                Email = "teste@teste.com"
            };

            var preferenceRequest = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest> { item },
                Payer = payer,
                PaymentMethods = new PreferencePaymentMethodsRequest
                {
                    Installments = 12 
                },
            };

            var preferenceClient = new PreferenceClient();

            Preference preference = await preferenceClient.CreateAsync(preferenceRequest);
            return preference.Id;
        }
    }
}
