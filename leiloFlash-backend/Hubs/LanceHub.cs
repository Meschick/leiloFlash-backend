using leiloFlash_backend.DTO.Lance;
using leiloFlash_backend.Services.Lance;
using Microsoft.AspNetCore.SignalR;

namespace leiloFlash_backend.Hubs
{
    public class LanceHub: Hub
    {
        private readonly ILanceService _lanceService;

        public LanceHub(ILanceService lanceService)
        {
            _lanceService = lanceService;
        }

        public async Task EnviarLance(LanceRequestDTO request, string email)
        {
            Console.WriteLine($"🔥 MÉTODO HUB EXECUTADO - Usuario: {email}, LoteId: {request.LoteId}, Valor: {request.Valor}");
            try
            {
                var lance = await _lanceService.DarLanceAsync(request);

                Console.WriteLine($"✅ LANCE PROCESSADO - Valor: {lance.Valor}, Usuario: {email}");

                await Clients.All.SendAsync("ReceberLance", new
                {
                    LoteId = lance.LoteId,
                    Valor = lance.Valor,
                    EmailUsuario = email,
                    DataHora = lance.DataHora
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERRO AO DAR LANCE: {ex.Message}");
                await Clients.Caller.SendAsync("ErroAoDarLance", ex.Message);
            }
        }

    }
}
